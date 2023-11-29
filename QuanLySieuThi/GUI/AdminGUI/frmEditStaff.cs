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
    public partial class frmEditStaff : Form
    {
        string pMaNV;
        private string fileAddress;

        NhanVienDTO nv_dto = new NhanVienDTO();
        List<NhanVienDTO> lst_nv = new List<NhanVienDTO>();

        NhanVienBLL nhanvien_bll = new NhanVienBLL();
        TaiKhoanBLL taiKhoan_bll = new TaiKhoanBLL();

        public frmEditStaff(string _manv)
        {
            InitializeComponent();
            pMaNV = _manv;
            this.Load += FrmEditProduct_Load;
            btnFinish.Click += BtnFinish_Click;
            btnGetPicture.Click += BtnGetPicture_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                nv_dto.manv = txtMaNV.Text;
                nv_dto.hoten = txtHoTen.Text;
                nv_dto.ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString());
                if (rdoNam.Checked)
                {
                    nv_dto.gioitinh = "Nam";
                }
                else
                {
                    nv_dto.gioitinh = "Nữ";
                }
                nv_dto.email = txtEmail.Text;
                nv_dto.sodienthoai = txtSDT.Text;
                nv_dto.anhdaidien = fileAddress;
                nv_dto.diachi = txtDiaChi.Text;
                nv_dto.matk = cboLoaiTK.SelectedItem.ToString();

                nhanvien_bll.editNV(nv_dto);
                MessageBox.Show("NHÂN VIÊN " + nv_dto.hoten.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            loadTaiKhoan();
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
                picStaff.Image = Image.FromFile(fileAddress);
                picStaff.ImageLocation = fileAddress;
            }
        }

        private void BtnGetPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void loadData()
        {
            lst_nv = nhanvien_bll.getDataNhanVienTheoMaNV(pMaNV);

            txtMaNV.Text = lst_nv[0].manv;
            txtHoTen.Text = lst_nv[0].hoten;
            dtpNgaySinh.Text = lst_nv[0].ngaysinh.ToString();
            if (lst_nv[0].gioitinh == "Nam")
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            txtEmail.Text = lst_nv[0].email;
            txtSDT.Text = lst_nv[0].sodienthoai;

            fileAddress = lst_nv[0].anhdaidien;
            if (fileAddress != string.Empty)
            {
                Image image = Image.FromFile(fileAddress);
                picStaff.Image = new Bitmap(image);
            }

            txtDiaChi.Text = lst_nv[0].diachi;
            cboLoaiTK.Text = lst_nv[0].matk;

        }

        private void loadTaiKhoan()
        {
            cboLoaiTK.DataSource = taiKhoan_bll.getDataTaiKhoan();
        }
    }
}
