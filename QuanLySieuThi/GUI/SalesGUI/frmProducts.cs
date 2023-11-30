using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace GUI.SalesGUI
{
    public partial class frmProducts : Form
    {
        CategoryUI[] productItems = new CategoryUI[30];
        SanPhamBLL sanpham_bll = new SanPhamBLL();
        KhuyenMaiDTO sale = new KhuyenMaiDTO();
        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();
        ChiTietKhuyenMaiBLL chitietkhuyenmai_bll = new ChiTietKhuyenMaiBLL();

        frmDetailProduct fDetailProduct;

        public frmProducts()
        {
            InitializeComponent();
            this.Load += FrmProducts_Load;
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            loadProductAllItems();
        }

        private void loadProductAllItems()
        {
            List<SanPhamDTO> products = new List<SanPhamDTO>();
            products = sanpham_bll.getDataSanPham();

            flpSanPham.Controls.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                productItems[i] = new CategoryUI();
                productItems[i].Width = 423;
                productItems[i].Margin = new Padding(3, 3, 0, 0);
                productItems[i].PMaSP = products[i].masp;
                productItems[i].PTenSp = products[i].tensp;
                productItems[i].PGiaSP = products[i].giasp.ToString("#,#") + " vnđ";
                try
                {
                    Image image = Image.FromFile("imgs/" + products[i].anhsanpham);
                    productItems[i].PAnh = new Bitmap(image);
                }
                catch (OutOfMemoryException)
                {

                }

                if (flpSanPham.Controls.Count < 0)
                {
                    flpSanPham.Controls.Clear();
                }
                else
                {
                    flpSanPham.Controls.Add(productItems[i]);
                }

                productItems[i].onSelect += (ss, ee) =>
                {
                    var wdg = (CategoryUI)ss;

                    fDetailProduct = new frmDetailProduct(wdg.PMaSP);
                    fDetailProduct.ShowDialog();
                };
            }
        }
    }
}
