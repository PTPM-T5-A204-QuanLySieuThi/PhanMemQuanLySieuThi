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
    public partial class frmPromotion : Form
    {
        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();

        frmAddPromotion fAddPromotion;
        frmEditPromotion fEditPromotion;

        string pMaKM, pTenKM;

        public frmPromotion()
        {
            InitializeComponent();
            this.Load += FrmPromotion_Load;
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
            loadDataPromotion();
            txtSearch.ResetText();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaKM = dgvPromotion.CurrentRow.Cells[0].Value.ToString();

            fEditPromotion = new frmEditPromotion(pMaKM);
            fEditPromotion.ShowDialog();
            loadDataPromotion();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaKM = dgvPromotion.CurrentRow.Cells[0].Value.ToString();
            pTenKM = dgvPromotion.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA KHUYẾN MÃI " + pTenKM.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (khuyenmai_bll.removeKM(pMaKM))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG KHUYẾN MÃI " + pTenKM.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    loadDataPromotion();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddPromotion = new frmAddPromotion();
            fAddPromotion.ShowDialog();
            loadDataPromotion();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPromotion.DataSource = khuyenmai_bll.getDataKhuyenMaiDK(txtSearch.Text);

            dgvPromotion.Columns[0].HeaderText = "MÃ VOUCHER";
            dgvPromotion.Columns[1].HeaderText = "TÊN VOUCHER";
            dgvPromotion.Columns[2].HeaderText = "CÒN HẠN";
            dgvPromotion.Columns[3].HeaderText = "SỐ GIẢM";
            dgvPromotion.Columns[4].HeaderText = "ĐIỀU KIỆN";
        }

        private void FrmPromotion_Load(object sender, EventArgs e)
        {
            loadDataPromotion();
        }

        private void loadDataPromotion()
        {
            dgvPromotion.DataSource = khuyenmai_bll.getDataKhuyenMai();

            dgvPromotion.Columns[0].HeaderText = "MÃ VOUCHER";
            dgvPromotion.Columns[1].HeaderText = "TÊN VOUCHER";
            dgvPromotion.Columns[2].HeaderText = "CÒN HẠN";
            dgvPromotion.Columns[3].HeaderText = "SỐ GIẢM";
            dgvPromotion.Columns[4].HeaderText = "ĐIỀU KIỆN";
        }
    }
}
