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

namespace GUI.SalesGUI
{
    public partial class frmDetailBill : Form
    {
        ProductBillUI[] productItems = new ProductBillUI[30];
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        KhuyenMaiDTO sale = new KhuyenMaiDTO();
        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();
        ChiTietKhuyenMaiBLL chitietkhuyenmai_bll = new ChiTietKhuyenMaiBLL();
        HoaDonBLL hoadon_nll = new HoaDonBLL();
        ChiTietHoaDonBLL cthoadon_nll = new ChiTietHoaDonBLL();

        List<HoaDonDTO> lst_hd = new List<HoaDonDTO>();
        List<ChiTietHoaDonDTO> lst_cthd = new List<ChiTietHoaDonDTO>();

        string pMaHD;

        public frmDetailBill(string _mahd)
        {
            InitializeComponent();
            pMaHD = _mahd;
            this.Load += FrmDetailBill_Load;
        }

        private void FrmDetailBill_Load(object sender, EventArgs e)
        {
            loadData();
            loadProductAllItems();
        }

        private void loadProductAllItems()
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPhamTheoMaHD(pMaHD);

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductBillUI();
                sale = khuyenmai_bll.getDataKhuyenMaiTheoMaSP(products[i].masp);
                productItems[i].Width = 500;
                productItems[i].Margin = new Padding(100, 20, 10, 0);
                productItems[i].PMaSP = products[i].masp;
                productItems[i].PTenSp = products[i].tensp;
                productItems[i].PGiaSP = products[i].giasp.ToString("N0") + " vnđ";

                lst_cthd = cthoadon_nll.getDataCTHoaDonTheoMaHD(pMaHD, products[i].masp);
                productItems[i].PSoLuong = "x" + lst_cthd[0].soluong.ToString();

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

                productItems[i].PThanhTien = (double.Parse(productItems[i].PGiaGiamSP.Replace(" vnđ", "").ToString().Replace(",","")) * lst_cthd[0].soluong).ToString("N0") + " vnđ";

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


                };
            }
        }

        private void loadData()
        {
            lst_hd = hoadon_nll.getDataHoaDonTheoMaHD(pMaHD);

            lbMaHD.Text = lst_hd[0].mahd;
            lbNgayLap.Text = lst_hd[0].ngaylap.ToString();
            lbMaNV.Text = lst_hd[0].manv;
            double temp = double.Parse(lst_hd[0].thanhtien.ToString().Replace(" vnđ", "").ToString().Replace(",", ""));
            lbThanhTien.Text = temp.ToString("N0") + " vnđ";


        }
    }
}
