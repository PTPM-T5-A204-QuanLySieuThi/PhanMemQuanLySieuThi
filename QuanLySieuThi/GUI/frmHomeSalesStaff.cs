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
using DTO;
using BLL;

namespace GUI
{
    public partial class frmHomeSalesStaff : MetroFramework.Forms.MetroForm
    {
        NhanVienBLL nhanvien_bll =new NhanVienBLL();

        public frmHomeSalesStaff()
        {
            InitializeComponent();
            loadDataCboStaffs();
            btnProduct.Click += BtnProduct_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin fLogin = new frmLogin();
            this.Hide();
            fLogin.Show();
            this.Close();
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            frmProduct fProduct = new frmProduct();
            fProduct.ShowDialog();
        }

        private void loadDataCboStaffs()
        {
            List<NhanVienDTO> lstStaffs = new List<NhanVienDTO>();

            lstStaffs = nhanvien_bll.getListNhanVienBanHang();

            cboStaffs.DataSource = lstStaffs;
            cboStaffs.DisplayMember = "hoten";
            cboStaffs.ValueMember = "manv";
        }
    }
}
