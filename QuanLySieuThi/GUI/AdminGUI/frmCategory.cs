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
    public partial class frmCategory : Form
    {
        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();

        frmAddStaff fAddStaff;
        frmEditStaff fEditStaff;

        string pMaLSP, pTenLSP;

        public frmCategory()
        {
            InitializeComponent();
            this.Load += FrmCategory_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLoad.Click += BtnLoad_Click;
            btnClearText.Click += BtnClearText_Click;
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            loadDataCategory();
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvCategory.DataSource = loaisanpham_bll.getDataLoaiSanPhamDK(txtSearch.Text);

            dgvCategory.Columns[0].HeaderText = "MÃ LOẠI SẢN PHẨM";
            dgvCategory.Columns[1].HeaderText = "TÊN LOẠI SẢN PHẨM";
        }

        private void loadDataCategory()
        {
            dgvCategory.DataSource = loaisanpham_bll.getDataLoaiSanPham();

            dgvCategory.Columns[0].HeaderText = "MÃ LOẠI SẢN PHẨM";
            dgvCategory.Columns[1].HeaderText = "TÊN LOẠI SẢN PHẨM";
        }
    }
}
