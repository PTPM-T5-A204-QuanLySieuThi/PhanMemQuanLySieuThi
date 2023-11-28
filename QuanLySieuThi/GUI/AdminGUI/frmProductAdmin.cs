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
    public partial class frmProductAdmin : Form
    {
        SanPhamBLL sanpham_bll = new SanPhamBLL();

        public frmProductAdmin()
        {
            InitializeComponent();
            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void FrmProductAdmin_Load(object sender, EventArgs e)
        {
            loadDataProduct();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.DataSource = sanpham_bll.getDataSanPhamLocDK(txtSearch.Text);

            dgvProduct.Columns[0].HeaderText = "MÃ SẢN PHẨM";
            dgvProduct.Columns[1].HeaderText = "BARCODE";
            dgvProduct.Columns[2].HeaderText = "TÊN SẢN PHẨM";
            dgvProduct.Columns[3].HeaderText = "NSX";
            dgvProduct.Columns[4].HeaderText = "HSD";
            dgvProduct.Columns[5].HeaderText = "GIÁ";
            dgvProduct.Columns[6].HeaderText = "SL TỒN";
        }

        private void loadDataProduct()
        {
            dgvProduct.DataSource = sanpham_bll.getDataSanPhamLoc();

            dgvProduct.Columns[0].HeaderText = "MÃ SẢN PHẨM";
            dgvProduct.Columns[1].HeaderText = "BARCODE";
            dgvProduct.Columns[2].HeaderText = "TÊN SẢN PHẨM";
            dgvProduct.Columns[3].HeaderText = "NSX";
            dgvProduct.Columns[4].HeaderText = "HSD";
            dgvProduct.Columns[5].HeaderText = "GIÁ";
            dgvProduct.Columns[6].HeaderText = "SL TỒN";
        }
    }
}
