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

namespace GUI.WarehouseGUI
{
    public partial class frmImportProduct : Form
    {
        string pMaSP;
        private string fileAddress;

        PhieuNhapKhoDTO pnk_dto = new PhieuNhapKhoDTO();
        List<SanPhamDTO> lst_sp = new List<SanPhamDTO>();

        SanPhamBLL sanpham_bll = new SanPhamBLL();
        PhieuNhapKhoBLL phieunhapkho_bll = new PhieuNhapKhoBLL();   
        NuocXuatXuBLL nuocxuatxu_bll = new NuocXuatXuBLL();
        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();
        DonViTinhBLL donvitinh_bll = new DonViTinhBLL();
        CTLoaiSanPhamBLL ctloaisanpham_bll = new CTLoaiSanPhamBLL();

        public frmImportProduct(string _masp)
        {
            InitializeComponent();

            pMaSP = _masp;
            this.Load += FrmEditProduct_Load;
            btnFinish.Click += BtnFinish_Click;
            txtGiaSi.ValueChanged += TxtGiaSi_ValueChanged;
            txtSLT.ValueChanged += TxtSLT_ValueChanged;
        }

        private void TxtSLT_ValueChanged(object sender, EventArgs e)
        {
            if (txtSLT.Value.ToString() != string.Empty && txtGiaSi.Value.ToString() != string.Empty)
            {
                decimal total = decimal.Parse(txtGiaSi.Value.ToString()) * int.Parse(txtSLT.Value.ToString());
                lbTongTien.Text = total + " vnđ";
            }
        }

        private void TxtGiaSi_ValueChanged(object sender, EventArgs e)
        {
            if (txtSLT.Value.ToString() != string.Empty && txtGiaSi.Value.ToString() != string.Empty)
            {
                decimal total = decimal.Parse(txtGiaSi.Value.ToString()) * int.Parse(txtSLT.Value.ToString());
                lbTongTien.Text = total + " vnđ";
            }    
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (txtSLT.Value.ToString() == string.Empty)
            {
                MessageBox.Show("CHƯA NHẬP SỐ LƯỢNG NHẬP", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
            else if (txtGiaSi.Value.ToString() == string.Empty)
            {
                MessageBox.Show("CHƯA NHẬP GIÁ SỈ", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
            else
            {
                try
                {
                    pnk_dto.maphieu = createCodeWarehouse();
                    pnk_dto.ngaynhap = DateTime.Now;
                    pnk_dto.masp = pMaSP;
                    pnk_dto.soluong = int.Parse(txtSLT.Text);
                    pnk_dto.tongtien = decimal.Parse(txtGiaSi.Text) * int.Parse(txtSLT.Text);
                    pnk_dto.ghichu = string.Empty;

                    phieunhapkho_bll.addPNK(pnk_dto);
                    sanpham_bll.importProduct(pMaSP, int.Parse(txtSLT.Text));
                    MessageBox.Show("NHẬP HÀNG THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_sp = sanpham_bll.getAllDataSanPhamTheoMaSP(pMaSP);


            lbMaSP.Text = lst_sp[0].masp;
            lbTenSP.Text = lst_sp[0].tensp;
            lbNXX.Text = nuocxuatxu_bll.getTenNuocXuatXu(lst_sp[0].masp);
            lbNCC.Text = nhacungcap_bll.getTenNhaCungCap(lst_sp[0].masp);
            lbDVT.Text = donvitinh_bll.getTenDonViTinh(lst_sp[0].masp);
            lbLSP.Text = ctloaisanpham_bll.getTenCTLoaiChiTiet(lst_sp[0].masp);

            fileAddress = "imgs/" + lst_sp[0].anhsanpham;
            Image image = Image.FromFile("imgs/" + lst_sp[0].anhsanpham);
            picProduct.Image = new Bitmap(image);
        }

        private string createCodeWarehouse()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(1000000, 10000000);
                pCode = "1010" + randomNumber.ToString("D6");

                if (!phieunhapkho_bll.checkPK(pCode))
                {
                    return pCode;
                }
            }
        }
    }
}
