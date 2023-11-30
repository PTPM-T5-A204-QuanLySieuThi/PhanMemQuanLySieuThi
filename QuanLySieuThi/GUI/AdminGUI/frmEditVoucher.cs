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
    public partial class frmEditVoucher : Form
    {
        string pMaVOR;

        VoucherDTO vor_dto = new VoucherDTO();
        List<VoucherDTO> lst_vor = new List<VoucherDTO>();

        VoucherBLL voucher_bll = new VoucherBLL();

        public frmEditVoucher(string _mavor)
        {
            InitializeComponent();
            pMaVOR = _mavor;
            this.Load += FrmEditVoucher_Load; ;
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

                voucher_bll.editVOR(vor_dto);
                MessageBox.Show("VOUCHER " + vor_dto.tenvor.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditVoucher_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_vor = voucher_bll.getDataVoucherDK(pMaVOR);

            txtMaVOR.Text = lst_vor[0].mavor;
            txtTenVOR.Text = lst_vor[0].tenvor;
            if (lst_vor[0].conhan)
            {
                chkConHan.Checked = true;
            }
            else
            {
                chkConHan.Checked = false;
            }
            txtSoGiam.Text = lst_vor[0].sogiam;
            txtDK.Text = lst_vor[0].dieukien;
        }
    }
}
