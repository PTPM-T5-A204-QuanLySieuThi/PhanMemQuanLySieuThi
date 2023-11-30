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
    public partial class frmEditCategory : Form
    {
        string pMaLSP;

        LoaiSanPhamDTO lsp_dto = new LoaiSanPhamDTO();
        List<LoaiSanPhamDTO> lst_lsp = new List<LoaiSanPhamDTO>();

        LoaiSanPhamBLL loaisanpham_bll = new LoaiSanPhamBLL();

        public frmEditCategory(string _malsp)
        {
            InitializeComponent();
            pMaLSP = _malsp;
            this.Load += FrmEditCategory_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lsp_dto.malsp = txtMaLSP.Text;
                lsp_dto.tenlsp = txtTenLSP.Text;

                loaisanpham_bll.editLSP(lsp_dto);
                MessageBox.Show("LOẠI SẢN PHẨM " + lsp_dto.tenlsp.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditCategory_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_lsp = loaisanpham_bll.getDataLoaiSanPhamTheoMaLSP(pMaLSP);

            txtMaLSP.Text = lst_lsp[0].malsp;
            txtTenLSP.Text = lst_lsp[0].tenlsp;
        }
    }
}
