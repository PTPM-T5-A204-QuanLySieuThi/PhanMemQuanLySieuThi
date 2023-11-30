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

        frmAddSupplier fAddSupplier;
        frmEditSupplier fEditSupplier;

        string pMaNCC, pTenNCC;

        public frmSupplier()
        {
            InitializeComponent();
            this.Load += FrmProductAdmin_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLoad.Click += BtnLoad_Click;
            btnClearText.Click += BtnClearText_Click;
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataSupplier();
            txtSearch.ResetText();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaNCC = dgvSupplier.CurrentRow.Cells[0].Value.ToString();

            fEditSupplier = new frmEditSupplier(pMaNCC);
            fEditSupplier.ShowDialog();
            loadDataSupplier();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaNCC = dgvSupplier.CurrentRow.Cells[0].Value.ToString();
            pTenNCC = dgvSupplier.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA NHÀ CUNG CẤP " + pTenNCC.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (nhacungcap_bll.removeNCC(pMaNCC))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG NHÀ CUNG CẤP " + pTenNCC.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    loadDataSupplier();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddSupplier = new frmAddSupplier();
            fAddSupplier.ShowDialog();
            loadDataSupplier();
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
