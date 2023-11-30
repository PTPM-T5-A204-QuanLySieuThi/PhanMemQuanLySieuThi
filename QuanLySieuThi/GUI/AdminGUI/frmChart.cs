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
    public partial class frmChart : Form
    {
        HoaDonBLL hoadon_bll =new HoaDonBLL();

        public frmChart()
        {
            InitializeComponent();
            this.Load += FrmChart_Load;
            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChart();
        }

        private void FrmChart_Load(object sender, EventArgs e)
        {
            loadYear();
            loadChart();
        }

        private void loadYear()
        {
            for (int i = 2023; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedIndex = 0;
        }

        private void loadChart()
        {
            chartBill.Series.Clear();
            chartBill.Series.Add("chartBill");

            int pYear = int.Parse(cboYear.SelectedItem.ToString());

            chartBill.Series["chartBill"].Points.AddXY("T1", hoadon_bll.calBillMonth(1, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T2", hoadon_bll.calBillMonth(2, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T3", hoadon_bll.calBillMonth(3, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T4", hoadon_bll.calBillMonth(4, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T5", hoadon_bll.calBillMonth(5, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T6", hoadon_bll.calBillMonth(6, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T7", hoadon_bll.calBillMonth(7, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T8", hoadon_bll.calBillMonth(8, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T9", hoadon_bll.calBillMonth(9, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T10", hoadon_bll.calBillMonth(10, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T11", hoadon_bll.calBillMonth(11, pYear));
            chartBill.Series["chartBill"].Points.AddXY("T12", hoadon_bll.calBillMonth(12, pYear));
        }
    }
}
