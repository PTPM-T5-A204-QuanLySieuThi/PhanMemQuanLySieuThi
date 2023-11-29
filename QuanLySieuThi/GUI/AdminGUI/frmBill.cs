using BLL;
using DTO;
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
    public partial class frmBill : Form
    {
        HoaDonBLL hoadon_bll = new HoaDonBLL();

        public frmBill()
        {
            InitializeComponent();
            this.Load += FrmBill_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            loadDataProduct();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = hoadon_bll.findDataHoaDon(txtSearch.Text);

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[2].HeaderText = "TỔNG TIỀN";
            dgvBill.Columns[3].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[4].HeaderText = "MÃ NHÂN VIÊN";
        }

        private void loadDataProduct()
        {
            dgvBill.DataSource = hoadon_bll.getDataHoaDon();

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[2].HeaderText = "TỔNG TIỀN";
            dgvBill.Columns[3].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[4].HeaderText = "MÃ NHÂN VIÊN";
        }
    }
}
