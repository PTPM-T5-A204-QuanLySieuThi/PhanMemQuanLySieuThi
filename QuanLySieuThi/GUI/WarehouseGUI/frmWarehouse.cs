using BLL;
using GUI.AdminGUI;
using GUI.SalesGUI;
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
    public partial class frmWarehouse : Form
    {
        SanPhamBLL sanpham_bll = new SanPhamBLL();

        frmImportProduct fImportProduct;

        string pMaSP, pTenSP;

        public frmWarehouse()
        {
            InitializeComponent();

            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnClearText.Click += BtnClearText_Click;
            dgvProduct.CellDoubleClick += DgvProduct_CellDoubleClick;
        }

        private void DgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();

            fImportProduct = new frmImportProduct(pMaSP);
            fImportProduct.ShowDialog();
            loadDataProduct();
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataProduct();
            txtSearch.ResetText();
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
            dgvProduct.DataSource = sanpham_bll.getAllDataSanPhamLoc();

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
