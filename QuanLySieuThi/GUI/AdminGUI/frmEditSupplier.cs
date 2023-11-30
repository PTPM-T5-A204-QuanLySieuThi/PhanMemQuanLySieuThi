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
    public partial class frmEditSupplier : Form
    {
        string pMaNCC;

        NhaCungCapDTO ncc_dto = new NhaCungCapDTO();
        List<NhaCungCapDTO> lst_ncc = new List<NhaCungCapDTO>();

        NhaCungCapBLL nhacungcap_bll = new NhaCungCapBLL();

        public frmEditSupplier(string _mancc)
        {
            InitializeComponent();
            pMaNCC = _mancc;
            this.Load += FrmEditSupplier_Load;
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

                nhacungcap_bll.editNCC(ncc_dto);
                MessageBox.Show("NHÀ CUNG CẤP " + ncc_dto.tenncc.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditSupplier_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_ncc = nhacungcap_bll.getDataNhaCungCapTheoMaNCC(pMaNCC);

            txtMaNCC.Text = lst_ncc[0].mancc;
            txtTenNCC.Text = lst_ncc[0].tenncc;
            txtDiaChi.Text = lst_ncc[0].diachi;
            txtSDT.Text = lst_ncc[0].sodienthoai;
        }
    }
}
