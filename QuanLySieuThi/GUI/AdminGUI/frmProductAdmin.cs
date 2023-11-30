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
using GUI.SalesGUI;

namespace GUI.AdminGUI
{
    public partial class frmProductAdmin : Form
    {
        SanPhamBLL sanpham_bll = new SanPhamBLL();

        frmAddProduct fAddProduct;
        frmEditProduct fEditProduct;
        frmDetailProduct fDetailProduct;

        string pMaSP, pTenSP;

        public frmProductAdmin()
        {
            InitializeComponent();
            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLoad.Click += BtnLoad_Click;
            btnClearText.Click += BtnClearText_Click;
            dgvProduct.CellDoubleClick += DgvProduct_CellDoubleClick;
        }

        private void DgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();

            fDetailProduct = new frmDetailProduct(pMaSP);
            fDetailProduct.ShowDialog();
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();

            fEditProduct = new frmEditProduct(pMaSP);
            fEditProduct.ShowDialog();
            loadDataProduct();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaSP = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            pTenSP = dgvProduct.CurrentRow.Cells[2].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA SẢN PHẨM " + pTenSP.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (sanpham_bll.removeSP(pMaSP))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG SẢN PHẨM " + pTenSP.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    loadDataProduct();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddProduct = new frmAddProduct();
            fAddProduct.ShowDialog();
            loadDataProduct();
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
