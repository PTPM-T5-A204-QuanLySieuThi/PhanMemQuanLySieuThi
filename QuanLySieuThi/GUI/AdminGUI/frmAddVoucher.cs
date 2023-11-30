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
    public partial class frmAddVoucher : Form
    {
        VoucherDTO vor_dto = new VoucherDTO();

        VoucherBLL voucher_bll = new VoucherBLL();

        public frmAddVoucher()
        {
            InitializeComponent();
            this.Load += FrmAddVoucher_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                vor_dto.mavor = txtMaVOR.Text;
                vor_dto.tenvor = txtTenVOR.Text;
                if (chkConHan.Checked)
                {
                    vor_dto.conhan = true;
                }
                else
                {
                    vor_dto.conhan = false;
                }
                vor_dto.sogiam = txtSoGiam.Text;
                vor_dto.dieukien = txtDK.Text;

                voucher_bll.addVOR(vor_dto);
                MessageBox.Show("VOUCHER " + txtTenVOR.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmAddVoucher_Load(object sender, EventArgs e)
        {
            txtMaVOR.Text = createCodePromotion();
        }

        private string createCodePromotion()
        {
            string pCode;
            int i = 1;

            while (true)
            {
                if (i > 0 && i < 10)
                {
                    pCode = "VR00" + i.ToString();
                }
                else
                {
                    pCode = "VR0" + i.ToString();
                }

                if (!voucher_bll.checkPK(pCode))
                {
                    return pCode;
                }

                i++;
            }
        }
    }
}
