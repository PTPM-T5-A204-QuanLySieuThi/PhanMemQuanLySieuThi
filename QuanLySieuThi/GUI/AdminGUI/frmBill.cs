using BLL;
using DTO;
using GUI.SalesGUI;
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
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        ChiTietHoaDonBLL chitiethoadon_bll = new ChiTietHoaDonBLL();

        HoaDonDTO hoadon_dto = new HoaDonDTO();

        frmDetailBillAdmin fDetailBillAdmin;

        public frmBill()
        {
            InitializeComponent();
            this.Load += FrmBill_Load;
            dtpTime.ValueChanged += DtpTime_ValueChanged;
            btnConfirm.Click += BtnConfirm_Click;
            dgvBill.DoubleClick += DgvBill_DoubleClick;
        }

        private void DgvBill_DoubleClick(object sender, EventArgs e)
        {
            string pCode = dgvBill.CurrentRow.Cells[0].Value.ToString();
            fDetailBillAdmin = new frmDetailBillAdmin(pCode);
            fDetailBillAdmin.ShowDialog();
            loadDataProduct();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string pMaHD = dgvBill.CurrentRow.Cells[0].Value.ToString();
            string pMaNV = dgvBill.CurrentRow.Cells[1].Value.ToString();
            string pMaKH = dgvBill.CurrentRow.Cells[2].Value.ToString();
            string pNgayLap = dgvBill.CurrentRow.Cells[3].Value.ToString();
            string pThanhTien = dgvBill.CurrentRow.Cells[4].Value.ToString();

            if (hoadon_bll.checkBillConfirm(pMaHD))
            {
                MessageBox.Show("HÓA ĐƠN NÀY ĐÃ THANH TOÁN", "PANDA MARTKET");
            }
            else
            {
                hoadon_dto.mahd = pMaHD;
                hoadon_dto.makh = pMaKH;
                hoadon_dto.manv = pMaNV;
                hoadon_dto.ngaylap = DateTime.Parse(pNgayLap);
                hoadon_dto.thanhtien = Decimal.Parse(pThanhTien);
                hoadon_dto.trangthai = true;

                hoadon_bll.editHD(hoadon_dto);
                
                foreach (var item in chitiethoadon_bll.getDataCTHoaDonTheoHD(pMaHD))
                {
                    sanpham_bll.updateSLT(pMaHD, item.masp);
                }
                MessageBox.Show("ĐÃ XÁC NHẬN THANH TOÁN THÀNH CÔNG", "PANDA MARTKET");
                loadDataProduct();
            }
        }

        private void DtpTime_ValueChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = hoadon_bll.findBillOnDate(DateTime.Parse(dtpTime.Value.ToString("dd/MM/yyy")));

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "MÃ NHÂN VIÊN";
            dgvBill.Columns[2].HeaderText = "MÃ KHÁCH HÀNG";
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
            dgvBill.Columns[1].HeaderText = "MÃ NHÂN VIÊN";
            dgvBill.Columns[2].HeaderText = "MÃ KHÁCH HÀNG";
            dgvBill.Columns[3].HeaderText = "NGÀY LẬP";
            dgvBill.Columns[4].HeaderText = "THÀNH TIỀN";
            dgvBill.Columns[5].HeaderText = "TRẠNG THÁI";
        }
    }
}
