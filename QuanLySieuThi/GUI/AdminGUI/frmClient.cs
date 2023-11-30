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
    public partial class frmClient : Form
    {
        KhachHangBLL khachhang_bll = new KhachHangBLL();

        frmAddClient fAddClient;
        frmEditClient fEditClient;

        string pMaKH, pTenKH;

        public frmClient()
        {
            InitializeComponent();
            this.Load += FrmClient_Load;
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
            pMaKH = dgvClient.CurrentRow.Cells[0].Value.ToString();

            fEditClient = new frmEditClient(pMaKH);
            fEditClient.ShowDialog();
            loadDataStaff();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            pMaKH = dgvClient.CurrentRow.Cells[0].Value.ToString();
            pTenKH = dgvClient.CurrentRow.Cells[1].Value.ToString();

            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA NHÂN VIÊN " + pTenKH.ToUpper() + " KHÔNG?", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == r)
            {
                if (khachhang_bll.removeKH(pMaKH))
                {
                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG KHÁCH HÀNG " + pTenKH.ToUpper(), "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
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
            fAddClient = new frmAddClient();
            fAddClient.ShowDialog();
            loadDataStaff();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvClient.DataSource = khachhang_bll.getDataKhachHangTheoMaKH(txtSearch.Text);

            dgvClient.Columns[0].HeaderText = "MÃ KHÁCH HÀNG";
            dgvClient.Columns[1].HeaderText = "HỌ TÊN";
            dgvClient.Columns[2].HeaderText = "ẢNH ĐẠI DIỆN";
            dgvClient.Columns[3].HeaderText = "NGÀY SINH";
            dgvClient.Columns[4].HeaderText = "GIỚI TÍNH";
            dgvClient.Columns[5].HeaderText = "ĐỊA CHỈ";
            dgvClient.Columns[6].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvClient.Columns[7].HeaderText = "MẬT KHẨU";
            dgvClient.Columns[8].HeaderText = "EMAIL";
            dgvClient.Columns[9].HeaderText = "TỈNH THÀNH";
            dgvClient.Columns[10].HeaderText = "ĐIỂM TÍCH LŨY";
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            loadDataStaff();
        }

        private void loadDataStaff()
        {
            dgvClient.DataSource = khachhang_bll.getDataKhachHang();

            dgvClient.Columns[0].HeaderText = "MÃ KHÁCH HÀNG";
            dgvClient.Columns[1].HeaderText = "HỌ TÊN";
            dgvClient.Columns[2].HeaderText = "ẢNH ĐẠI DIỆN";
            dgvClient.Columns[3].HeaderText = "NGÀY SINH";
            dgvClient.Columns[4].HeaderText = "GIỚI TÍNH";
            dgvClient.Columns[5].HeaderText = "ĐỊA CHỈ";
            dgvClient.Columns[6].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvClient.Columns[7].HeaderText = "MẬT KHẨU";
            dgvClient.Columns[8].HeaderText = "EMAIL";
            dgvClient.Columns[9].HeaderText = "TỈNH THÀNH";
            dgvClient.Columns[10].HeaderText = "ĐIỂM TÍCH LŨY";
        }
    }
}
