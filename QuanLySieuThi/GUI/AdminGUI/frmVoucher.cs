using BLL;
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
    public partial class frmVoucher : Form
    {
        VoucherBLL voucher_bll = new VoucherBLL();

        frmAddVoucher fAddVoucher;
        frmEditVoucher fEditVoucher;

        string pMaVOR, pTenVOR;

        public frmVoucher()
        {
            InitializeComponent();
            this.Load += FrmVoucher_Load;
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
            loadDataVoucher();
            txtSearch.ResetText();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaVOR = dgvVoucher.CurrentRow.Cells[0].Value.ToString();

            fEditVoucher = new frmEditVoucher(pMaVOR);
            fEditVoucher.ShowDialog();
            loadDataVoucher();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaVOR = dgvVoucher.CurrentRow.Cells[0].Value.ToString();
            pTenVOR = dgvVoucher.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA VOUCHER " + pTenVOR.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (voucher_bll.removeVOR(pMaVOR))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG VOUCHER " + pTenVOR.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    loadDataVoucher();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddVoucher = new frmAddVoucher();
            fAddVoucher.ShowDialog();
            loadDataVoucher();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvVoucher.DataSource = voucher_bll.getDataVoucherDK(txtSearch.Text);

            dgvVoucher.Columns[0].HeaderText = "MÃ VOUCHER";
            dgvVoucher.Columns[1].HeaderText = "TÊN VOUCHER";
            dgvVoucher.Columns[2].HeaderText = "CÒN HẠN";
            dgvVoucher.Columns[3].HeaderText = "SỐ GIẢM";
            dgvVoucher.Columns[4].HeaderText = "ĐIỀU KIỆN";
        }

        private void FrmVoucher_Load(object sender, EventArgs e)
        {
            loadDataVoucher();
        }

        private void loadDataVoucher()
        {
            dgvVoucher.DataSource = voucher_bll.getDataVoucher();

            dgvVoucher.Columns[0].HeaderText = "MÃ VOUCHER";
            dgvVoucher.Columns[1].HeaderText = "TÊN VOUCHER";
            dgvVoucher.Columns[2].HeaderText = "CÒN HẠN";
            dgvVoucher.Columns[3].HeaderText = "SỐ GIẢM";
            dgvVoucher.Columns[4].HeaderText = "ĐIỀU KIỆN";
        }
    }
}
