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

namespace GUI.AdminGUI
{
    public partial class frmSupplier : Form
    {
        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();

        public frmSupplier()
        {
            InitializeComponent();
            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void FrmProductAdmin_Load(object sender, EventArgs e)
        {
            loadDataSupplier();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSupplier.DataSource = nhacungcap_bll.findDataNhaCungCap(txtSearch.Text);

            dgvSupplier.Columns[0].HeaderText = "MÃ NHÀ CUNG CẤP";
            dgvSupplier.Columns[1].HeaderText = "TÊN NHÀ CUNG CẤP";
            dgvSupplier.Columns[2].HeaderText = "ĐỊA CHỈ";
            dgvSupplier.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
        }

        private void loadDataSupplier()
        {
            dgvSupplier.DataSource = nhacungcap_bll.getDataNhaCungCap();

            dgvSupplier.Columns[0].HeaderText = "MÃ NHÀ CUNG CẤP";
            dgvSupplier.Columns[1].HeaderText = "TÊN NHÀ CUNG CẤP";
            dgvSupplier.Columns[2].HeaderText = "ĐỊA CHỈ";
            dgvSupplier.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
        }
    }
}
