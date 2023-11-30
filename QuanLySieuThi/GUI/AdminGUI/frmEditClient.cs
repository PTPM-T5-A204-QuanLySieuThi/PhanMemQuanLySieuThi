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
    public partial class frmEditClient : Form
    {
        string pMaKH;
        private string fileAddress;

        KhachHangDTO kh_dto = new KhachHangDTO();
        List<KhachHangDTO> lst_kh = new List<KhachHangDTO>();

        KhachHangBLL khachhang_bll = new KhachHangBLL();

        public frmEditClient(string _makh)
        {
            InitializeComponent();
            pMaKH = _makh;
            this.Load += frmEditClient_Load;
            btnFinish.Click += BtnFinish_Click;
            btnGetPicture.Click += BtnGetPicture_Click;
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
                kh_dto.diemtichluy = decimal.Parse(txtDTL.Text);

                khachhang_bll.editKH(kh_dto);
                MessageBox.Show("KHÁCH HÀNG " + kh_dto.hoten.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void frmEditClient_Load(object sender, EventArgs e)
        {
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
            lst_kh = khachhang_bll.getDataKhachHangTheoMaKH(pMaKH);

            txtMaKH.Text = lst_kh[0].makh;
            txtHoTen.Text = lst_kh[0].hoten;
            dtpNgaySinh.Text = lst_kh[0].ngaysinh.ToString();
            if (lst_kh[0].gioitinh == "Nam")
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            txtEmail.Text = lst_kh[0].email;
            txtSDT.Text = lst_kh[0].sodienthoai;

            fileAddress = lst_kh[0].anhdaidien;
            if (fileAddress != string.Empty)
            {
                Image image = Image.FromFile(fileAddress);
                picStaff.Image = new Bitmap(image);
            }

            txtDiaChi.Text = lst_kh[0].diachi;
            txtMK.Text = lst_kh[0].matkhau;
            txtTinhThanh.Text = lst_kh[0].tinhthanh;
            txtDTL.Text = lst_kh[0].diemtichluy.ToString();

        }
    }
}
