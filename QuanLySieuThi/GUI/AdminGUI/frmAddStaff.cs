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
    public partial class frmAddStaff : Form
    {
        private string fileAddress;

        NhanVienDTO nv_dto = new NhanVienDTO();

        NhanVienBLL nhanvien_bll = new NhanVienBLL();
        TaiKhoanBLL taiKhoan_bll = new TaiKhoanBLL();

        public frmAddStaff()
        {
            InitializeComponent();
            this.Load += FrmAddStaff_Load;
            btnGetPicture.Click += BtnGetPicture_Click;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                nv_dto.manv = txtMaNV.Text;
                nv_dto.hoten = txtHoTen.Text;
                nv_dto.ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString());
                if(rdoNam.Checked)
                {
                    nv_dto.gioitinh = "Nam";
                }
                else
                {
                    nv_dto.gioitinh = "Nữ";
                }
                nv_dto.email = txtEmail.Text;
                nv_dto.sodienthoai = txtSDT.Text;
                nv_dto.anhdaidien = fileAddress.Replace("C:\\Users\\admin\\OneDrive - Ho Chi Minh city University of Industry and Trade\\HUFI\\NAM4\\HOCKY1\\PTPM\\DoAn_QuanLySieuThi\\PhanMemQuanLySieuThi\\QuanLySieuThi\\GUI\\imgs\\", "");
                nv_dto.diachi = txtDiaChi.Text;
                nv_dto.matk = cboLoaiTK.SelectedItem.ToString();

                nhanvien_bll.addNV(nv_dto);
                MessageBox.Show("NHÂN VIÊN " + txtHoTen.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
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

        private void FrmAddStaff_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = createCodeStaff();
            loadTaiKhoan();
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

        private void loadTaiKhoan()
        {
            cboLoaiTK.DataSource = taiKhoan_bll.getDataTaiKhoan();
        }

        private string createCodeStaff()
        {
            Random random = new Random();
            string pCode;

            while (true)
            {
                int randomNumber = random.Next(1000, 10000);
                pCode = "101" + randomNumber.ToString("D4");

                if (!nhanvien_bll.checkPK(pCode))
                {
                    return pCode;
                }
            }
        }
    }
}
