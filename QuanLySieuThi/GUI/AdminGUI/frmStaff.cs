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
    public partial class frmStaff : Form
    {
        NhanVienBLL nhanvien_bll = new NhanVienBLL();

        frmAddStaff fAddStaff;
        frmEditStaff fEditStaff;

        string pMaNV, pTenNV;

        public frmStaff()
        {
            InitializeComponent();
            this.Load += FrmStaff_Load;
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
            loadDataStaff();
            txtSearch.ResetText();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pMaNV = dgvStaff.CurrentRow.Cells[0].Value.ToString();

            fEditStaff = new frmEditStaff(pMaNV);
            fEditStaff.ShowDialog();
            loadDataStaff();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaNV = dgvStaff.CurrentRow.Cells[0].Value.ToString();
            pTenNV = dgvStaff.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA NHÂN VIÊN " + pTenNV.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (nhanvien_bll.removeNV(pMaNV))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG NHÂN VIÊN " + pTenNV.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                    loadDataStaff();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddStaff = new frmAddStaff();
            fAddStaff.ShowDialog();
            loadDataStaff();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvStaff.DataSource = nhanvien_bll.getListNhanVien();

            dgvStaff.Columns[0].HeaderText = "MÃ NHÂN VIÊN";
            dgvStaff.Columns[1].HeaderText = "HỌ TÊN";
            dgvStaff.Columns[2].HeaderText = "ẢNH ĐẠI DIỆN";
            dgvStaff.Columns[3].HeaderText = "NGÀY SINH";
            dgvStaff.Columns[4].HeaderText = "GIỚI TÍNH";
            dgvStaff.Columns[5].HeaderText = "ĐỊA CHỈ";
            dgvStaff.Columns[6].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvStaff.Columns[7].HeaderText = "EMAIL";
            dgvStaff.Columns[8].HeaderText = "MÃ TÀI KHOẢN";
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            loadDataStaff();
        }

        private void loadDataStaff()
        {
            dgvStaff.DataSource = nhanvien_bll.getListNhanVien();

            dgvStaff.Columns[0].HeaderText = "MÃ NHÂN VIÊN";
            dgvStaff.Columns[1].HeaderText = "HỌ TÊN";
            dgvStaff.Columns[2].HeaderText = "ẢNH ĐẠI DIỆN";
            dgvStaff.Columns[3].HeaderText = "NGÀY SINH";
            dgvStaff.Columns[4].HeaderText = "GIỚI TÍNH";
            dgvStaff.Columns[5].HeaderText = "ĐỊA CHỈ";
            dgvStaff.Columns[6].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvStaff.Columns[7].HeaderText = "EMAIL";
            dgvStaff.Columns[8].HeaderText = "MÃ TÀI KHOẢN";
        }
    }
}
