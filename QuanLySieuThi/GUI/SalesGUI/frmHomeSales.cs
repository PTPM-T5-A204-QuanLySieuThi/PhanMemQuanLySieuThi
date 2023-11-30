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
    public partial class frmHomeSales : Form
    {
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();
        HoaDonBLL hoadon_bll = new HoaDonBLL();

        public frmHomeSales()
        {
            InitializeComponent();
            this.Load += FrmHomeSales_Load;
        }

        private void FrmHomeSales_Load(object sender, EventArgs e)
        {
            setLabel();
        }

        private void setLabel()
        {
            lbProduct.Text = sanpham_bll.countProduct().ToString();
            lbCategory.Text = loaisanpham_bll.countCategory().ToString();
            lbSalesVolume.Text = hoadon_bll.countBillDaily().ToString();
            lbRevenue.Text = hoadon_bll.calBillDaily().ToString("N0") + " vnđ";
        }
    }
}
