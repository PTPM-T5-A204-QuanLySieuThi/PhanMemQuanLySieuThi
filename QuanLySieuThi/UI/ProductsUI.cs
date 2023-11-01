using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductsUI : UserControl
    {
        public ProductsUI()
        {
            InitializeComponent();
        }

        private Image pAnh;
        private string pTenSp;
        private string pGiaGiamSP;
        private string pGiaSP;
        private string pKhuyenMai;

        [Category("Custom Product")]
        public Image PAnh 
        {
            get { return  pAnh; }
            set { pAnh = value; picProduct.Image = value; }
        }

        [Category("Custom Product")]
        public string PTenSp
        {
            get { return pTenSp; }
            set { pTenSp = value; lbTenSP.Text = value; }
        }

        [Category("Custom Product")]
        public string PGiaGiamSP
        {
            get { return pGiaGiamSP; }
            set { pGiaGiamSP = value; lbGiaGiam.Text = value; }
        }

        [Category("Custom Product")]
        public string PGiaSP
        {
            get { return pGiaSP; }
            set { pGiaSP = value; lbGiaSP.Text = value; }
        }

        [Category("Custom Product")]
        public string PKhuyenMai
        {
            get { return pKhuyenMai; }
            set { pKhuyenMai = value; lbKhuyenMai.Text = value; }
        }
    }
}
