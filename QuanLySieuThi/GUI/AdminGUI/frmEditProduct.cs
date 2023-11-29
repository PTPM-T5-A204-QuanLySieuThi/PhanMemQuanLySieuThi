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

namespace GUI.AdminGUI
{
    public partial class frmEditProduct : Form
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

        public frmEditProduct(string _masp)
        {
            InitializeComponent();
            pMaSP = _masp;
            this.Load += FrmEditProduct_Load;
            btnFinish.Click += BtnFinish_Click;
            btnGetPicture.Click += BtnGetPicture_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                sp_dto.masp = txtMaSP.Text;
                sp_dto.barcode = txtBarcode.Text;
                sp_dto.tensp = txtTenSP.Text;
                sp_dto.ngaysx = DateTime.Parse(dtpNSX.Value.ToString());
                sp_dto.hansd = DateTime.Parse(dtpHSD.Value.ToString());
                sp_dto.slton = int.Parse(txtSLT.Text);
                sp_dto.mota = txtMota.Text;
                if (fileAddress.Contains("C:\\Users\\admin\\OneDrive - Ho Chi Minh city University of Industry and Trade\\HUFI\\NAM4\\HOCKY1\\PTPM\\DoAn_QuanLySieuThi\\PhanMemQuanLySieuThi\\QuanLySieuThi\\GUI\\imgs\\"))
                {
                    sp_dto.anhsanpham = fileAddress.Replace("C:\\Users\\admin\\OneDrive - Ho Chi Minh city University of Industry and Trade\\HUFI\\NAM4\\HOCKY1\\PTPM\\DoAn_QuanLySieuThi\\PhanMemQuanLySieuThi\\QuanLySieuThi\\GUI\\imgs\\", "");
                }
                else
                {
                    sp_dto.anhsanpham = fileAddress.Replace("imgs/", "");
                }
                sp_dto.giasp = decimal.Parse(txtGia.Text);
                sp_dto.manxx = cboNXX.SelectedValue.ToString();
                sp_dto.mancc = cboNCC.SelectedValue.ToString();
                sp_dto.madvt = cboDVT.SelectedValue.ToString();
                sp_dto.mactlsp = cboCTLSP.SelectedValue.ToString();

                sanpham_bll.editSP(sp_dto);
                MessageBox.Show("SẢN PHẨM " + sp_dto.tensp.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            loadNuocXuatXu();
            loadNhaCungCap();
            loadDonViTinh();
            loadCTLoaiSanPham();
            loadData();
        }

        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "CHỌN ẢNH SẢN PHẨM";

            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                picProduct.Image = Image.FromFile(fileAddress);
                picProduct.ImageLocation = fileAddress;
            }
        }

        private void BtnGetPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void loadData()
        {
            lst_sp = sanpham_bll.getDataSanPhamTheoMaSP(pMaSP);


            txtMaSP.Text = lst_sp[0].masp;
            txtBarcode.Text = lst_sp[0].barcode;
            txtTenSP.Text = lst_sp[0].tensp;
            txtGia.Text = lst_sp[0].giasp.ToString();
            dtpNSX.Text = lst_sp[0].ngaysx.ToString();
            dtpHSD.Text = lst_sp[0].hansd.ToString();

            fileAddress = "imgs/" + lst_sp[0].anhsanpham;
            Image image = Image.FromFile("imgs/" + lst_sp[0].anhsanpham);
            picProduct.Image = new Bitmap(image);

            txtSLT.Text = lst_sp[0].slton.ToString();
            txtMota.Text = lst_sp[0].mota;
            cboNXX.SelectedValue = lst_sp[0].manxx;
            cboNCC.SelectedValue = lst_sp[0].mancc.ToString();
            cboDVT.SelectedValue = lst_sp[0].madvt.ToString();
            cboCTLSP.SelectedValue = lst_sp[0].mactlsp.ToString();

        }

        private void loadNuocXuatXu()
        {
            cboNXX.DataSource = nuocxuatxu_bll.getDataNuocXuatXu();
            cboNXX.ValueMember = "MANXX";
            cboNXX.DisplayMember = "TENNXX";
        }

        private void loadNhaCungCap()
        {
            cboNCC.DataSource = nhacungcap_bll.getDataNhaCungCap();
            cboNCC.ValueMember = "MANCC";
            cboNCC.DisplayMember = "TENNCC";
        }

        private void loadDonViTinh()
        {
            cboDVT.DataSource = donvitinh_bll.getDataDonViTinh();
            cboDVT.ValueMember = "MADVT";
            cboDVT.DisplayMember = "TENDVT";
        }

        private void loadCTLoaiSanPham()
        {
            cboCTLSP.DataSource = ctloaisanpham_bll.getDataCTLoaiSanPham();
            cboCTLSP.ValueMember = "MACTLSP";
            cboCTLSP.DisplayMember = "TENCTLSP";
        }
    }
}
