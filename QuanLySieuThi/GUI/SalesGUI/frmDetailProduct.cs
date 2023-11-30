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

namespace GUI.SalesGUI
{
    public partial class frmDetailProduct : Form
    {
        string pMaSP;
        private string fileAddress;

        SanPhamDTO sp_dto = new SanPhamDTO();
        List<SanPhamDTO> lst_sp = new List<SanPhamDTO>();

        SanPhamBLL sanpham_bll = new SanPhamBLL();
        NuocXuatXuBLL nuocxuatxu_bll = new NuocXuatXuBLL();
        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();
        DonViTinhBLL donvitinh_bll = new DonViTinhBLL();
        CTLoaiSanPhamBLL ctloaisanpham_bll = new CTLoaiSanPhamBLL();

        public frmDetailProduct(string _masp)
        {
            InitializeComponent();
            pMaSP = _masp;
            this.Load += FrmDetailProduct_Load;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDetailProduct_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_sp = sanpham_bll.getDataSanPhamTheoMaSP(pMaSP);

            lbMaSP.Text = lst_sp[0].masp;
            lbBarcode.Text = lst_sp[0].barcode;
            lbTenSP.Text = lst_sp[0].tensp;
            lbGia.Text = lst_sp[0].giasp.ToString();
            lbNSX.Text = lst_sp[0].ngaysx.ToString("dd/MM/yyyy");
            lbHSD.Text = lst_sp[0].hansd.ToString("dd/MM/yyyy");

            fileAddress = "imgs/" + lst_sp[0].anhsanpham;
            Image image = Image.FromFile("imgs/" + lst_sp[0].anhsanpham);
            picProduct.Image = new Bitmap(image);

            lbSLT.Text = lst_sp[0].slton.ToString();
            lbMoTa.Text = lst_sp[0].mota;
            lbNXX.Text = nuocxuatxu_bll.getTenNuocXuatXu(lst_sp[0].masp);
            lbNCC.Text = nhacungcap_bll.getTenNhaCungCap(lst_sp[0].masp);
            lbDVT.Text = donvitinh_bll.getTenDonViTinh(lst_sp[0].masp);
            lbLSP.Text = ctloaisanpham_bll.getTenCTLoaiChiTiet(lst_sp[0].masp);
        }
    }
}
