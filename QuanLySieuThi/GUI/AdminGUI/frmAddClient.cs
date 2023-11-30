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
    public partial class frmAddClient : Form
    {
        private string fileAddress;

        KhachHangDTO kh_dto = new KhachHangDTO();

        KhachHangBLL khachhang_bll = new KhachHangBLL();

        public frmAddClient()
        {
            InitializeComponent();
            this.Load += frmAddClient_Load;
            btnGetPicture.Click += BtnGetPicture_Click;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                kh_dto.makh = txtMaKH.Text;
                kh_dto.hoten = txtHoTen.Text;
                kh_dto.ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString());
                if (rdoNam.Checked)
                {
                    kh_dto.gioitinh = "Nam";
                }
                else
                {
                    kh_dto.gioitinh = "Nữ";
                }
                kh_dto.email = txtEmail.Text;
                kh_dto.sodienthoai = txtSDT.Text;
                kh_dto.anhdaidien = fileAddress;
                kh_dto.diachi = txtDiaChi.Text;
                kh_dto.matkhau = txtMK.Text;
                kh_dto.tinhthanh = txtTinhThanh.Text;
                kh_dto.diemtichluy = 0;

                khachhang_bll.addKH(kh_dto);
                MessageBox.Show("KHÁCH HÀNG " + txtHoTen.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
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

        private void frmAddClient_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = createCodeClient();
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
    }
}
