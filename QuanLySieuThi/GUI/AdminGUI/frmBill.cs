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
            dtpTime.ValueChanged += DtpTime_ValueChanged;
        }

        private void DtpTime_ValueChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = hoadon_bll.findBillOnDate(dtpTime.Value);

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "MÃ KHÁCH HÀNG";
            dgvBill.Columns[2].HeaderText = "MÃ NHÂN VIÊN";
            dgvBill.Columns[3].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[4].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[5].HeaderText = "TRẠNG THÁI";
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            loadDataProduct();
        }

        private void loadDataProduct()
        {
            dgvBill.DataSource = hoadon_bll.getDataHoaDon();

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "MÃ KHÁCH HÀNG";
            dgvBill.Columns[2].HeaderText = "MÃ NHÂN VIÊN";
            dgvBill.Columns[3].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[4].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[5].HeaderText = "TRẠNG THÁI";
        }
    }
}
