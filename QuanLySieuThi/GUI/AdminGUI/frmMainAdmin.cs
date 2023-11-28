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
    public partial class frmMainAdmin : Form
    {
        bool expand1 = true;
        bool expand2 = true;

        frmProductAdmin fProductAdmin = new frmProductAdmin();

        public frmMainAdmin()
        {
            InitializeComponent();

            timerNavigationMenu1 = new Timer();
            timerNavigationMenu1.Interval = 10;
            timerNavigationMenu1.Enabled = true;

            timerNavigationMenu2 = new Timer();
            timerNavigationMenu2.Interval = 10;
            timerNavigationMenu2.Enabled = true;

            timerNavigationMenu1.Tick += TimerNavigationMenu1_Tick;
            timerNavigationMenu2.Tick += TimerNavigationMenu2_Tick;

            this.Load += FrmMainAdmin_Load;

            //------------------ BUTTON CHA
            btnHome.Click += BtnHome_Click;
            btnManager.Click += BtnManager_Click;
            btnStatistics.Click += BtnStatistics_Click;
            btnLogout.Click += BtnLogout_Click;

            //------------------ BUTTON CON
            btnProduct.Click += BtnProduct_Click;

        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fProductAdmin.TopLevel = false;
            fProductAdmin.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fProductAdmin);
            fProductAdmin.Show();
        }

        private void FrmMainAdmin_Load(object sender, EventArgs e)
        {
            setSizeFrom();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            pnStatistics.Visible = true;
            pnHome.Visible = false;
            pnManager.Visible = false;
            pnLogout.Visible = false;

            //if (!expand1)
            //{
            //    timerNavigationMenu1.Start();
            //    expand2 = true;
            //}


            timerNavigationMenu2.Start();
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            pnManager.Visible = true;
            pnHome.Visible = false;
            pnStatistics.Visible = false;
            pnLogout.Visible = false;

            //if (!expand2)
            //{
            //    timerNavigationMenu2.Start();
            //    expand1 = true;
            //}

            timerNavigationMenu1.Start();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            pnHome.Visible = true;
            pnManager.Visible = false;
            pnStatistics.Visible = false;
            pnLogout.Visible = false;
        }

        private void TimerNavigationMenu1_Tick(object sender, EventArgs e)
        {
            if (!expand1)
            {
                dropDownMenu1.Height += 15;
                if (dropDownMenu1.Height >= dropDownMenu1.MaximumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = true;
                }
            }
            else
            {
                dropDownMenu1.Height -= 15;
                if (dropDownMenu1.Height <= dropDownMenu1.MinimumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = false;
                }
            }
        }

        private void TimerNavigationMenu2_Tick(object sender, EventArgs e)
        {
            if (!expand2)
            {
                dropDownMenu2.Height += 15;
                if (dropDownMenu2.Height >= dropDownMenu2.MaximumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = true;
                }
            }
            else
            {
                dropDownMenu2.Height -= 15;
                if (dropDownMenu2.Height <= dropDownMenu2.MinimumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = false;
                }
            }
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
