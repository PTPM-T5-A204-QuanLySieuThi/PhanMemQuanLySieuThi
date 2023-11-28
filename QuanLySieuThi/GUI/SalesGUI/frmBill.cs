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

namespace GUI.SalesGUI
{
    public partial class frmBill : Form
    {
        HoaDonBLL hoadon_bll = new HoaDonBLL();

        frmDetailBill fDetailBill;

        public frmBill()
        {
            InitializeComponent();
            this.Load += FrmBill_Load;
            dgvBill.DoubleClick += DgvBill_DoubleClick;
        }

        private void DgvBill_DoubleClick(object sender, EventArgs e)
        {
            string pCode = dgvBill.CurrentRow.Cells[0].Value.ToString();
            fDetailBill = new frmDetailBill(pCode);
            fDetailBill.ShowDialog();
            loadDataBill();
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            loadDataBill();
        }

        private void loadDataBill()
        {
            dgvBill.DataSource = hoadon_bll.getDataHoaDon();

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[2].HeaderText = "TỔNG TIỀN";
            dgvBill.Columns[3].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[4].HeaderText = "CÓ VOUCHER";
        }
    }
}
