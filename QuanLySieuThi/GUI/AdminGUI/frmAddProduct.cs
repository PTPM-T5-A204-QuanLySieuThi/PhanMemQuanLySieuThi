using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.AdminGUI
{
    public partial class frmAddProduct : Form
    {
        private string fileAddress;

        SanPhamDTO sp_dto = new SanPhamDTO();

        SanPhamBLL sanpham_bll = new SanPhamBLL();
        NuocXuatXuBLL nuocxuatxu_bll = new NuocXuatXuBLL();
        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();
        DonViTinhBLL donvitinh_bll = new DonViTinhBLL();
        CTLoaiSanPhamBLL ctloaisanpham_bll = new CTLoaiSanPhamBLL();

        public frmAddProduct()
        {
            InitializeComponent();
            this.Load += FrmAddProduct_Load;
            btnGetPicture.Click += BtnGetPicture_Click;
            btnFinish.Click += BtnFinish_Click;
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
                sp_dto.anhsanpham = fileAddress.Replace("C:\\Users\\admin\\OneDrive - Ho Chi Minh city University of Industry and Trade\\HUFI\\NAM4\\HOCKY1\\PTPM\\DoAn_QuanLySieuThi\\PhanMemQuanLySieuThi\\QuanLySieuThi\\GUI\\imgs\\", "");
                sp_dto.giasp = decimal.Parse(txtGia.Text);
                sp_dto.manxx = cboNXX.SelectedValue.ToString();
                sp_dto.mancc = cboNCC.SelectedValue.ToString();
                sp_dto.madvt = cboDVT.SelectedValue.ToString();
                sp_dto.mactlsp = cboCTLSP.SelectedValue.ToString();

                sanpham_bll.addSP(sp_dto);
                MessageBox.Show("SẢN PHẨM " + txtTenSP.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void BtnGetPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = createCodeProduct();
            loadNuocXuatXu();
            loadNhaCungCap();
            loadDonViTinh();
            loadCTLoaiSanPham();
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

        private string createCodeProduct()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(1000000, 10000000);
                pCode = randomNumber.ToString("D7");

                if (!sanpham_bll.checkPK(pCode))
                {
                    return pCode;
                }
            }
        }
    }
}
