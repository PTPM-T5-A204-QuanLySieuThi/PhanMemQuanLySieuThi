using AForge.Video.DirectShow;
using AForge.Video;
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using ZXing;

namespace GUI.SalesGUI
{
    public partial class frmSales : Form
    {
        NhanVienBLL nhanvien_bll = new NhanVienBLL();
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();
        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();
        ChiTietKhuyenMaiBLL chitietkhuyenmai_bll = new ChiTietKhuyenMaiBLL();
        HoaDonDTO hoadon_dto = new HoaDonDTO();
        ChiTietHoaDonDTO chitiethoadon_dto = new ChiTietHoaDonDTO();
        HoaDonBLL hoadon_bll = new HoaDonBLL();
        ChiTietHoaDonBLL chitiethoadon_bll = new ChiTietHoaDonBLL();

        ProductsUI[] productItems = new ProductsUI[30];
        List<string> lstCam = new List<string>();
        KhuyenMaiDTO sale = new KhuyenMaiDTO();

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public frmSales()
        {
            InitializeComponent();
            this.Load += FrmSales_Load;
            btnClearAll.Click += BtnClearAll_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboLSP.SelectedIndexChanged += CboLSP_SelectedIndexChanged;
            chkVoucher.CheckedChanged += ChkVoucher_CheckedChanged;
            chkPoints.CheckedChanged += ChkPoints_CheckedChanged;
            btnPay.Click += BtnPay_Click;
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            loadDataCboStaffs();
            loadProductAllItems();
            loadLSP();
            loadCam();
            runCam();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.RowCount > 0)
                {
                    hoadon_dto.mahd = createCodeBill();
                    hoadon_dto.ngaylap = DateTime.Now;
                    hoadon_dto.tongtien = decimal.Parse(lbTotalTemp.Text.Replace(" vnđ", "").ToString().Replace(",", ""));
                    hoadon_dto.thanhtien = decimal.Parse(lbTotal.Text.Replace(" vnđ", "").ToString().Replace(",", ""));
                    hoadon_dto.manv = cboStaffs.SelectedValue.ToString();

                    hoadon_bll.addHD(hoadon_dto);

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        string pMaSP = string.Empty;
                        pMaSP = sanpham_bll.getMaSanPham(item.Cells["TenSP"].Value.ToString());

                        chitiethoadon_dto.mahd = hoadon_dto.mahd;
                        chitiethoadon_dto.masp = pMaSP;
                        chitiethoadon_dto.soluong = int.Parse(item.Cells["SoLuong"].Value.ToString());

                        chitiethoadon_bll.addHD(chitiethoadon_dto);
                        sanpham_bll.updateSoLuongTon(pMaSP, int.Parse(item.Cells["SoLuong"].Value.ToString()));
                    }

                    guna2DataGridView1.Rows.Clear();
                    lbTotal.Text = lbTotalTemp.Text = "0 vnđ";
                    chkVoucher.Checked = false;
                    txtVoucher.ResetText();

                    MessageBox.Show("THANH TOÁN THÀNH CÔNG", "PANDA MARTKET");
                }
                else
                {
                    MessageBox.Show("KHÔNG THỂ THANH TOÁN HÓA ĐƠN KHI KHÔNG CÓ SẢN PHẨM", "PANDA MARTKET");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("THANH TOÁN THẤT BẠI", "PANDA MARTKET");
            }
        }

        private void ChkVoucher_CheckedChanged(object sender)
        {
            isVoucher();
        }

        private void ChkPoints_CheckedChanged(object sender)
        {
            isPoints();
        }

        private void CboLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLSP.SelectedIndex == 0)
            {
                loadProductAllItems();
            }
            else
            {
                string _malsp = cboLSP.SelectedValue.ToString();
                loadProductItemsCategory(_malsp);
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            lbTotal.Text = lbTotalTemp.Text = "0 vnđ";
            chkVoucher.Checked = false;
            txtVoucher.ResetText();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                loadProductAllItems();
            }
            else
            {
                loadProductItemsSearch(txtSearch.Text);
            }
        }

        private void loadDataCboStaffs()
        {
            List<NhanVienDTO> lstStaffs = new List<NhanVienDTO>();

            lstStaffs = nhanvien_bll.getListNhanVienBanHang();

            cboStaffs.DataSource = lstStaffs;
            cboStaffs.DisplayMember = "hoten";
            cboStaffs.ValueMember = "manv";
        }

        private void loadProductAllItems()
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPham();

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                sale = khuyenmai_bll.getDataKhuyenMaiTheoMaSP(products[i].masp);
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].masp;
                productItems[i].PTenSp = products[i].tensp;
                if (chitietkhuyenmai_bll.isKhuyenMai(products[i].masp))
                {
                    productItems[i].PKhuyenMai = sale.sogiam.ToString() + "%";
                    productItems[i].PGiaSP = products[i].giasp.ToString("N0") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("N0") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("N0") + " vnđ";
                }
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].anhsanpham);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    bool flag = false;

                    var wdg = (ProductsUI)ss;

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (item.Cells["TenSP"].Value == wdg.PTenSp)
                        {
                            item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                            item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" vnđ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("N3") + " vnđ";
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaGiamSP, wdg.PGiaGiamSP });
                    }
                    tinhThanhTien();
                };
            }
        }

        private void loadProductItemsSearch(string pValue)
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPhamDK(pValue);

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                sale = khuyenmai_bll.getDataKhuyenMaiTheoMaSP(products[i].masp);
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].masp;
                productItems[i].PTenSp = products[i].tensp;
                if (chitietkhuyenmai_bll.isKhuyenMai(products[i].masp))
                {
                    productItems[i].PKhuyenMai = sale.sogiam.ToString() + "%";
                    productItems[i].PGiaSP = products[i].giasp.ToString("N0") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("N0") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("N0") + " vnđ";
                }
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].anhsanpham);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    bool flag = false;

                    var wdg = (ProductsUI)ss;

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (item.Cells["TenSP"].Value == wdg.PTenSp)
                        {
                            item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                            item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" vnđ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("N3") + " vnđ";
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaGiamSP, wdg.PGiaGiamSP });
                    }
                    tinhThanhTien();
                };
            }
        }

        private void loadProductItemsCategory(string pValue)
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPhamCategory(pValue);

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                sale = khuyenmai_bll.getDataKhuyenMaiTheoMaSP(products[i].masp);
                productItems[i].Width = 203;
                productItems[i].Margin = new Padding(6, 10, 10, 6);
                productItems[i].PMaSP = products[i].masp;
                productItems[i].PTenSp = products[i].tensp;
                if (chitietkhuyenmai_bll.isKhuyenMai(products[i].masp))
                {
                    productItems[i].PKhuyenMai = sale.sogiam.ToString() + "%";
                    productItems[i].PGiaSP = products[i].giasp.ToString("N0") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("N0") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("N0") + " vnđ";
                }
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].anhsanpham);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    bool flag = false;

                    var wdg = (ProductsUI)ss;

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (item.Cells["TenSP"].Value == wdg.PTenSp)
                        {
                            item.Cells["SoLuong"].Value = (int.Parse(item.Cells["SoLuong"].Value.ToString()) + 1).ToString();
                            item.Cells["SoTien"].Value = (double.Parse(item.Cells["GiaSP"].Value.ToString().Replace(" vnđ", "")) * int.Parse(item.Cells["SoLuong"].Value.ToString())).ToString("N3") + " vnđ";
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        guna2DataGridView1.Rows.Add(new object[] { wdg.PTenSp, 1, wdg.PGiaGiamSP, wdg.PGiaGiamSP });
                    }
                    tinhThanhTien();
                };
            }
        }

        private void loadLSP()
        {
            cboLSP.DataSource = loaisanpham_bll.getDataLoaiSanPham();
            cboLSP.DisplayMember = "TENLSP";
            cboLSP.ValueMember = "MALSP";
            cboLSP.SelectedIndex = 0;
        }

        private void runCam()
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfoCollection)
            {
                cboCam.Items.Add(item.Name);
            }
            cboCam.SelectedIndex = 0;

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitMap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitMap);
            if (result != null)
            {
                txtSearch.Invoke(new MethodInvoker(delegate ()
                {
                    txtSearch.Text = result.ToString();
                }));
            }
            picBarcode.Image = bitMap;
        }

        private void stopCam()
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                    picBarcode.Image = null;
                }
            }
        }

        private void loadCam()
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfoCollection)
            {
                lstCam.Add(item.Name);
            }
        }

        private void tinhThanhTien()
        {
            double total = 0;
            double lamTron = 0;
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += Convert.ToDouble(item.Cells["SoTien"].Value.ToString().Replace(" vnđ", "").ToString().Replace(",", ""));
            }

            lbTotalTemp.Text = total.ToString("N0") + " vnđ";
            lamTron = Math.Round(total);
            lbTotal.Text = lamTron.ToString("N0") + " vnđ";
        }

        private void isVoucher()
        {
            if (chkVoucher.Checked)
            {
                txtVoucher.Visible = true;
            }
            else
            {
                txtVoucher.Visible = false;
            }
        }

        private void isPoints()
        {
            if (chkPoints.Checked)
            {
                txtPhone.Visible = true;
            }
            else
            {
                txtPhone.Visible = false;
            }
        }

        private string createCodeBill()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(100000, 1000000);
                pCode = "1002" + randomNumber.ToString("D6");

                if (!hoadon_bll.checkPK(pCode))
                {
                    return pCode;
                }
            }
        }

        private string createCodeTichDiem()
        {
            Random random = new Random();
            string pCode;

            int randomNumber = random.Next(100000, 1000000);
            pCode = randomNumber.ToString("D6");
            return pCode;
        }
    }
}
