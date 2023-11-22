using BLL;
using DTO;
using Guna.UI2.WinForms;
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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using Guna.UI2.AnimatorNS;

namespace GUI.SalesGUI
{
    public partial class frmMainSales : Form
    {
        NhanVienBLL nhanvien_bll = new NhanVienBLL();
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();
        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();
        ChiTietKhuyenMaiBLL chitietkhuyenmai_bll = new ChiTietKhuyenMaiBLL();

        frmLogin fLogin = new frmLogin();
        frmProduct fProduct = new frmProduct();

        ProductsUI[] productItems = new ProductsUI[12];
        List<string> lstCam = new List<string>();
        KhuyenMaiDTO sale = new KhuyenMaiDTO();

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public frmMainSales()
        {
            InitializeComponent();
            this.Load += FrmMainSales_Load;
            btnSale.Click += BtnSale_Click;
            btnProduct.Click += BtnProduct_Click;
            btnClient.Click += BtnClient_Click;
            btnBill.Click += BtnBill_Click;
            btnLogout.Click += BtnLogout_Click;
            btnClearAll.Click += BtnClearAll_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboLSP.SelectedIndexChanged += CboLSP_SelectedIndexChanged;
            chkVoucher.CheckedChanged += ChkVoucher_CheckedChanged;
        }

        private void ChkVoucher_CheckedChanged(object sender)
        {
            isVoucher();
        }

        private void CboLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboLSP.SelectedIndex == 0)
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
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                loadProductAllItems();
            }
            else
            {
                loadProductItemsSearch(txtSearch.Text);
            }
        }

        private void BtnSale_Click(object sender, EventArgs e)
        {
            changeColorButtonEnter(btnSale);
            changeColorButtonNormal(btnProduct);
            changeColorButtonNormal(btnClient);
            changeColorButtonNormal(btnBill);
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            changeColorButtonEnter(btnProduct);
            changeColorButtonNormal(btnSale);
            changeColorButtonNormal(btnClient);
            changeColorButtonNormal(btnBill);

            //pnlBody.Controls.Clear();
            //fProduct.TopLevel = false;
            //fProduct.Dock = DockStyle.Fill;
            //pnlBody.Controls.Add(fProduct);
            //fProduct.Show();

            fProduct.ShowDialog();
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            changeColorButtonEnter(btnClient);
            changeColorButtonNormal(btnProduct);
            changeColorButtonNormal(btnSale);
            changeColorButtonNormal(btnBill);
        }

        private void BtnBill_Click(object sender, EventArgs e)
        {
            changeColorButtonEnter(btnBill);
            changeColorButtonNormal(btnProduct);
            changeColorButtonNormal(btnClient);
            changeColorButtonNormal(btnSale);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            fLogin.Show();
            this.Close();
        }

        private void FrmMainSales_Load(object sender, EventArgs e)
        {
            setSizeFrom();
            loadDataCboStaffs();
            loadProductAllItems();
            loadLSP();
            loadCam();
            runCam();
        }

        private void loadDataCboStaffs()
        {
            List<NhanVienDTO> lstStaffs = new List<NhanVienDTO>();

            lstStaffs = nhanvien_bll.getListNhanVienBanHang();

            cboStaffs.DataSource = lstStaffs;
            cboStaffs.DisplayMember = "hoten";
            cboStaffs.ValueMember = "manv";
        }

        private void changeColorButtonEnter(Guna2Button btn)
        {
            btn.FillColor = SystemColors.MenuHighlight;
            btn.ForeColor = Color.White;
        }

        private void changeColorButtonNormal(Guna2Button btn)
        {
            btn.FillColor = Color.White;
            btn.ForeColor = Color.Black;
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
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
                    productItems[i].PGiaSP = products[i].giasp.ToString("#,#") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("#,#") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("#,#") + " vnđ";
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
                    productItems[i].PGiaSP = products[i].giasp.ToString("#,#") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("#,#") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("#,#") + " vnđ";
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
                    productItems[i].PGiaSP = products[i].giasp.ToString("#,#") + " vnđ";
                    productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - ((double)sale.sogiam / 100))).ToString("#,#") + " vnđ";
                }
                else
                {
                    productItems[i].PKhuyenMai = string.Empty;
                    productItems[i].PGiaSP = string.Empty;
                    productItems[i].PGiaGiamSP = products[i].giasp.ToString("#,#") + " vnđ";
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
            if(result != null)
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
            if(videoCaptureDevice != null)
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
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                total += Convert.ToDouble(item.Cells["SoTien"].Value.ToString().Replace(" vnđ", ""));
            }
            lbTotal.Text = total.ToString("N3") + " vnđ";
            lbTotalTemp.Text = total.ToString("N3") + " vnđ";
        }

        private void isVoucher()
        {
            if (chkVoucher.Checked)
            {
                lbVoucher.Visible = true;
                txtVoucher.Visible = true;
            }
            else
            {
                lbVoucher.Visible = false;
                txtVoucher.Visible = false;
            }
        }
    }
}
