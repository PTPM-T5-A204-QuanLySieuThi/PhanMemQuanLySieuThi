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
    public partial class frmAddSupplier : Form
    {
        NhaCungCapDTO ncc_dto = new NhaCungCapDTO();

        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();

        public frmAddSupplier()
        {
            InitializeComponent();
            this.Load += FrmAddSupplier_Load; ;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                ncc_dto.mancc = txtMaNCC.Text;
                ncc_dto.tenncc = txtTenNCC.Text;
                ncc_dto.diachi = txtDiaChi.Text;
                ncc_dto.sodienthoai = txtSDT.Text;

                nhacungcap_bll.addNCC(ncc_dto);
                MessageBox.Show("NHÀ CUNG CẤP " + txtTenNCC.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmAddSupplier_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = createCodeCategory();
        }

        private string createCodeCategory()
        {
            string pCode;
            int i = 1;

            while (true)
            {
                if (i > 0 && i < 10)
                {
                    pCode = "CC00" + i.ToString();
                }
                else
                {
                    pCode = "CC0" + i.ToString();
                }

                if (!nhacungcap_bll.checkPK(pCode))
                {
                    return pCode;
                }

                i++;
            }
        }
    }
}
