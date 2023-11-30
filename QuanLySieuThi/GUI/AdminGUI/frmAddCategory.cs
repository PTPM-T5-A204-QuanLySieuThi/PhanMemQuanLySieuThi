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
    public partial class frmAddCategory : Form
    {
        LoaiSanPhamDTO lsp_dto = new LoaiSanPhamDTO();

        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();

        public frmAddCategory()
        {
            InitializeComponent();
            this.Load += FrmAddCategory_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lsp_dto.malsp = txtMaLSP.Text;
                lsp_dto.tenlsp = txtTenLSP.Text;

                loaisanpham_bll.addLSP(lsp_dto);
                MessageBox.Show("LOẠI SẢN PHẨM " + txtTenLSP.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            txtMaLSP.Text = createCodeCategory();
        }

        private string createCodeCategory()
        {
            string pCode;
            int i = 0;

            while (true)
            {
                if(i >= 0 && i < 10)
                {
                    pCode = "LS00" + i.ToString();
                }
                else
                {
                    pCode = "LS0" + i.ToString();
                }

                if (!loaisanpham_bll.checkPK(pCode))
                {
                    return pCode;
                }

                i++;
            }
        }
    }
}
