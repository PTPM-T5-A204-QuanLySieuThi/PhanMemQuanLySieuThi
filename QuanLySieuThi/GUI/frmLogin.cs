using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        QuyenTruyCapBLL qtc_bll = new QuyenTruyCapBLL();
        TaiKhoanBLL tk_bll = new TaiKhoanBLL();

        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
            btnLogin.Click += BtnLogin_Click;
            btnShowPS.Click += BtnShowPS_Click;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            loadCboRole();
            txtPS.UseSystemPasswordChar = true;
            cboRole.SelectedIndex = Properties.Settings.Default.role;
            txtPS.Text = Properties.Settings.Default.password;
            chkRememberPS.Checked = Properties.Settings.Default.isRemember;
        }

        private void BtnShowPS_Click(object sender, EventArgs e)
        {
            if(btnShowPS.Tag.ToString() == "showPS")
            {
                txtPS.UseSystemPasswordChar = true;
                btnShowPS.Tag = "hidePS";
                Image showPass = Properties.Resources.close_eyes_32;
                btnShowPS.Image = showPass;
                return;
            }
            else
            {
                txtPS.UseSystemPasswordChar = false;
                btnShowPS.Tag = "showPS";
                Image hidePass = Properties.Resources.open_eyes_32;
                btnShowPS.Image = hidePass;
                return;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int pRole = cboRole.SelectedIndex;
            string pPassword = txtPS.Text;
            string pRoleValue = cboRole.SelectedValue.ToString();
            if(tk_bll.isSuccessLogin(pRoleValue, pPassword))
            {
                rememberPS(pRole, pPassword);
                frmLoading fLoading = new frmLoading(pRoleValue, pPassword);
                fLoading.Show();
                this.Hide();
            }
            else
            {
                lbError.Text = "Kiểm tra lại mật khẩu";
            }
        }

        public void rememberPS(int pRole, string pPassword)
        {
            if (chkRememberPS.Checked)
            {
                Properties.Settings.Default.role = pRole;
                Properties.Settings.Default.password = pPassword;
                Properties.Settings.Default.isRemember = true;

                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.role = pRole;
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.isRemember = false;

                Properties.Settings.Default.Save();
            }
        }

        public void loadCboRole()
        {
            List<string> lst_tqtc = new List<string>();
            lst_tqtc = qtc_bll.getListTenQuyenTruyCap();
            lst_tqtc.Add("---- CHỌN VAI TRÒ ----");
            lst_tqtc.Sort();
            cboRole.DataSource = lst_tqtc;
        }
    }
}
