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
    public partial class frmMainWarehouse : Form
    {
        public frmMainWarehouse()
        {
            InitializeComponent();
            this.Load += FrmMainWarehouse_Load;
            btnHome.Click += BtnHome_Click;
            btnImportProduct.Click += BtnImportProduct_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void BtnImportProduct_Click(object sender, EventArgs e)
        {
            pnImportProduct.Visible = true;
            pnHome.Visible = false;
            pnLogout.Visible = false;
        }

        private void FrmMainWarehouse_Load(object sender, EventArgs e)
        {
            setSizeFrom();
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
