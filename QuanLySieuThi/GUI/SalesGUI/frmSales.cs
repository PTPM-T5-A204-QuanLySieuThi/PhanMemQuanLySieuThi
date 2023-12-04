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
using System.Runtime.CompilerServices;

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
        KhachHangDTO khachhang_dto = new KhachHangDTO();
        HoaDonBLL hoadon_bll = new HoaDonBLL();
        KhachHangBLL khachhang_bll = new KhachHangBLL();
        ChiTietHoaDonBLL chitiethoadon_bll = new ChiTietHoaDonBLL();

        ProductsUI[] productItems = new ProductsUI[30];
        List<string> lstCam = new List<string>();
        KhuyenMaiDTO sale = new KhuyenMaiDTO();

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        string _mahd, _masp;

        public frmSales()
        {
            InitializeComponent();
            this.Load += FrmSales_Load;
            btnClearAll.Click += BtnClearAll_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboLSP.SelectedIndexChanged += CboLSP_SelectedIndexChanged;
            btnPay.Click += BtnPay_Click;
            txtClientGive.TextChanged += TxtClientGive_TextChanged;
            pdBill.PrintPage += PdBill_PrintPage;
        }

        private void PdBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var hoadon = hoadon_bll.getDataHoaDonTheoMaHD(_mahd);
            var chitiethoadon = chitiethoadon_bll.getDataCTHoaDonTheoHD(_mahd);

            var w = pdBill.DefaultPageSettings.PaperSize.Width;

            //------------- VẼ HEADER CỦA BILL
            //--- 1/ TÊN CỬA HÀNG 
            e.Graphics.DrawString("PHIẾU THANH TOÁN BÁCH HÓA PANDA MARTKET", new Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, new Point(130, 20));
            e.Graphics.DrawString("Số CT:" + hoadon[0].mahd + "-" + hoadon[0].ngaylap + "-NV:" + hoadon[0].manv, new Font("Segoe UI", 13, FontStyle.Regular), Brushes.Black, new Point(220, 50));

            //------------- VẼ LINE
            Pen blackPen = new Pen(Color.Black, 1);

            var y = 100;

            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //------------- VẼ BODY CỦA BILL
            //--- 1/ TỰA ĐỀ
            e.Graphics.DrawString("SL", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(100, 120));
            e.Graphics.DrawString("Giá bán (có VAT)", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(300, 120));
            e.Graphics.DrawString("Thành tiền", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, 120));

            //--- 2/ TÊN SẢN PHẨM
            y = 150;
            for(int i = 0; i < chitiethoadon.Count; i++)
            {
                var sanpham = sanpham_bll.getDataSanPhamTheoMaSP(chitiethoadon[i].masp);
                sale = khuyenmai_bll.getDataKhuyenMaiTheoMaSP(chitiethoadon[i].masp);

                e.Graphics.DrawString(sanpham[0].tensp.ToUpper(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(70, y));
                e.Graphics.DrawString(chitiethoadon[i].soluong.ToString(), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(100, y + 30));
               
                if(sale != null)
                {
                    e.Graphics.DrawString(sanpham[0].giasp.ToString("N0"), new Font("Segoe UI", 16, FontStyle.Strikeout), Brushes.Gray, new Point(250, y + 30));
                    e.Graphics.DrawString((sanpham[0].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("N0"), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(370, y + 30));
                }
                else
                {
                    e.Graphics.DrawString(sanpham[0].giasp.ToString("N0"), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(370, y + 30));
                }

                e.Graphics.DrawString(chitiethoadon[i].tongtien.ToString("N0"), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(700, y + 30));

                y += 60;
            }

            //------------- VẼ LINE
            y += 20;
            blackPen = new Pen(Color.Black, 1);

            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //--- 3/ TIỀN THANH TOÁN
            y += 20;
            e.Graphics.DrawString("Phải thanh toán", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(70, y));
            e.Graphics.DrawString(hoadon[0].thanhtien.ToString("N0"), new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, y));

            //------------- VẼ LINE
            y += 40;
            blackPen = new Pen(Color.Black, 1);

            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            e.Graphics.DrawLine(blackPen, p1, p2);

            //--- 3/ TIỀN KHÁCH TRẢ
            y += 20;
            e.Graphics.DrawString("Tiền khách đưa", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(70, y));
            e.Graphics.DrawString(txtClientGive.Text, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, new Point(700, y));

            e.Graphics.DrawString("Tiền thối lại", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(70, y + 30));
            e.Graphics.DrawString(lbTienThoi.Text.Replace(" vnđ", ""), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(700, y + 30));

        }

        private void TxtClientGive_TextChanged(object sender, EventArgs e)
        {
            //exportBill(); 
            string money = txtClientGive.Text.Replace(",", "");

            decimal number;
            if (Decimal.TryParse(money, out number))
            {
                if (txtClientGive.Text == string.Empty)
                {
                    txtClientGive.Text = string.Empty;
                }
                else
                {
                    lbTienThoi.Text = (number - decimal.Parse(lbTotal.Text.Replace(" vnđ", "").ToString().Replace(",", ""))).ToString("N0") + " vnđ";
                }

                txtClientGive.Text = number.ToString("N0");
                txtClientGive.SelectionStart = txtClientGive.Text.Length;
            }
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
                    if (txtClientGive.Text != string.Empty)
                    {
                        hoadon_dto.mahd = createCodeBill();
                        hoadon_dto.ngaylap = DateTime.Now;
                        hoadon_dto.thanhtien = decimal.Parse(lbTotal.Text.Replace(" vnđ", "").ToString().Replace(",", ""));
                        hoadon_dto.manv = cboStaffs.SelectedValue.ToString();

                        if (txtPhone.Text != string.Empty)
                        {
                            if (khachhang_bll.checkPhoneNum(txtPhone.Text))
                            {
                                hoadon_dto.makh = khachhang_bll.findCodeClient(txtPhone.Text);
                            }
                            else
                            {
                                hoadon_dto.makh = createCodeClient();

                                khachhang_dto.makh = createCodeClient();
                                khachhang_dto.hoten = string.Empty;
                                khachhang_dto.anhdaidien = string.Empty;
                                khachhang_dto.ngaysinh = DateTime.Now;
                                khachhang_dto.gioitinh = string.Empty;
                                khachhang_dto.diachi = string.Empty;
                                khachhang_dto.sodienthoai = txtPhone.Text;
                                khachhang_dto.matkhau = string.Empty;
                                khachhang_dto.email = string.Empty;
                                khachhang_dto.tinhthanh = string.Empty;
                                khachhang_dto.diemtichluy = 0;

                                khachhang_bll.addKH(khachhang_dto);
                            }

                            hoadon_dto.trangthai = false;

                            hoadon_bll.addHD(hoadon_dto);

                            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                            {
                                string pMaSP = string.Empty;
                                pMaSP = sanpham_bll.getMaSanPham(item.Cells["TenSP"].Value.ToString());

                                chitiethoadon_dto.mahd = hoadon_dto.mahd;
                                chitiethoadon_dto.masp = pMaSP;
                                chitiethoadon_dto.soluong = int.Parse(item.Cells["SoLuong"].Value.ToString());
                                chitiethoadon_dto.tongtien = decimal.Parse(item.Cells["SoTien"].Value.ToString().Replace(" vnđ", "").ToString().Replace(",", ""));
                                chitiethoadon_bll.addHD(chitiethoadon_dto);
                                sanpham_bll.updateSoLuongTon(pMaSP, int.Parse(item.Cells["SoLuong"].Value.ToString()));
                            }

                            guna2DataGridView1.Rows.Clear();
                            lbTotal.Text = lbTotalTemp.Text = "0 vnđ";

                            _mahd = hoadon_dto.mahd;

                            exportBill();

                            MessageBox.Show("THANH TOÁN THÀNH CÔNG", "PANDA MARTKET");

                            loadProductAllItems();

                            resetInput();
                        }
                        else
                        {
                            MessageBox.Show("VUI LÒNG NHẬP SỐ ĐIỆN THOẠI CỦA KHÁCH HÀNG", "PANDA MARTKET");
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("CHƯA NHẬP TIỀN KHÁCH ĐƯA", "PANDA MARTKET");
                    }
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
            resetInput();
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
                productItems[i].PSLTon = products[i].slton.ToString();
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
                    var wdg = (ProductsUI)ss;

                    if (sanpham_bll.getSLT(wdg.PMaSP) != 0)
                    {
                        bool flag = false;

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
                    }
                    else
                    {
                        MessageBox.Show("SẢN PHẨM ĐÃ HẾT HÀNG", "PANDA MARTKET");
                    }
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
                productItems[i].PSLTon = products[i].slton.ToString();
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
                productItems[i].PSLTon = products[i].slton.ToString();
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

        private string createCodeClient()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(1000, 10000);
                pCode = "201" + randomNumber.ToString("D4");

                if (!khachhang_bll.checkPK(pCode))
                {
                    return pCode;
                }
            }
        }

        private void resetInput()
        {
            guna2DataGridView1.Rows.Clear();
            lbTotal.Text = lbTotalTemp.Text = lbTienThoi.Text = "0 vnđ";
            txtPhone.ResetText();
            txtClientGive.ResetText();
            chkPoints.Checked = false;
        }

        private string createCodeTichDiem()
        {
            Random random = new Random();
            string pCode;

            int randomNumber = random.Next(100000, 1000000);
            pCode = randomNumber.ToString("D6");
            return pCode;
        }

         private void exportBill()
        {
            ppdBill.Document = pdBill;
            ppdBill.ShowDialog();
        }
    }
}
