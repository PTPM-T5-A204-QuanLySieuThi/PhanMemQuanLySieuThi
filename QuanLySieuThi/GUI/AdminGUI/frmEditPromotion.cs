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
    public partial class frmEditPromotion : Form
    {
        string pMaKM;

        KhuyenMaiDTO km_dto = new KhuyenMaiDTO();
        List<KhuyenMaiDTO> lst_km = new List<KhuyenMaiDTO>();

        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();

        public frmEditPromotion(string _makm)
        {
            InitializeComponent();
            pMaKM = _makm;
            this.Load += FrmEditPromotion_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                km_dto.makm = txtMaKM.Text;
                km_dto.tenkm = txtTenKM.Text;
                km_dto.ngaybatdau = DateTime.Parse(dtpNBD.Text);
                km_dto.ngayketthuc = DateTime.Parse(dtpNKT.Text);
                km_dto.sogiam = int.Parse(txtSoGiam.Text);

                khuyenmai_bll.editKM(km_dto);
                MessageBox.Show("KHUYẾM MÃI " + km_dto.tenkm.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmEditPromotion_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lst_km = khuyenmai_bll.getDataKhuyenMaiTheoMaKM(pMaKM);

            txtMaKM.Text = lst_km[0].makm;
            txtTenKM.Text = lst_km[0].tenkm;
            dtpNBD.Text = lst_km[0].ngaybatdau.ToString();
            dtpNKT.Text = lst_km[0].ngayketthuc.ToString();
            txtSoGiam.Text = lst_km[0].sogiam.ToString();
        }
    }
}
