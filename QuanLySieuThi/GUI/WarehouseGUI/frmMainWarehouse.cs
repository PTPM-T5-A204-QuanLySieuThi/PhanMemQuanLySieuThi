using GUI.AdminGUI;
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
        frmWarehouse fWarehouse = new frmWarehouse();

        public frmMainWarehouse()
        {
            InitializeComponent();
            this.Load += FrmMainWarehouse_Load;
            btnImportProduct.Click += BtnImportProduct_Click;
            btnLogout.Click += BtnLogout_Click;
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
            pnLogout.Visible = false;

            pnlBody.Controls.Clear();
            fWarehouse.TopLevel = false;
            fWarehouse.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fWarehouse);
            fWarehouse.Show();
        }

        private void FrmMainWarehouse_Load(object sender, EventArgs e)
        {
            setSizeFrom();

            pnlBody.Controls.Clear();
            fWarehouse.TopLevel = false;
            fWarehouse.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fWarehouse);
            fWarehouse.Show();
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
