using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace GUI
{
    public partial class frmProduct : MetroFramework.Forms.MetroForm
    {
        SanPhamBLL sanpham_bll = new SanPhamBLL();

        public frmProduct()
        {
            InitializeComponent();
            this.Load += FrmProduct_Load;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            loadProductItems();
        }

        private void loadProductItems()
        {
            ProductsUI[] productItems = new ProductsUI[12];

            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPham();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new ProductsUI();
                productItems[i].Width = 296;
                productItems[i].Margin = new Padding(10, 3, 10, 15);
                productItems[i].PAnh = Image.FromFile("imgs/" + products[i].anhsanpham);
                productItems[i].PTenSp = products[i].tensp;
                productItems[i].PGiaSP = products[i].giasp.ToString("#,#") + " vnđ";
                productItems[i].PGiaGiamSP = (products[i].giasp * (decimal)(1 - 0.17)).ToString("#,#") + " vnđ";

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }    
            }
        }

        private void setPictureAvatar(Image pAnhSP, string pPath)
        {
            
        }
    }
}
