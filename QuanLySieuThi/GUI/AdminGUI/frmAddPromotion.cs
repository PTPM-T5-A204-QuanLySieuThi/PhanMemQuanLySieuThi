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
    public partial class frmAddPromotion : Form
    {
        KhuyenMaiDTO km_dto = new KhuyenMaiDTO();

        KhuyenMaiBLL khuyenmai_bll = new KhuyenMaiBLL();

        public frmAddPromotion()
        {
            InitializeComponent();
            this.Load += FrmAddPromotion_Load;
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

                khuyenmai_bll.addKM(km_dto);
                MessageBox.Show("KHUYẾN MÃI " + txtTenKM.Text.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM QUẢN LÝ CỦA HÀNG BÁCH HÓA");
            }
        }

        private void FrmAddPromotion_Load(object sender, EventArgs e)
        {
            txtMaKM.Text = createCodePromotion();
        }

        private string createCodePromotion()
        {
            string pCode;
            int i = 1;

            while (true)
            {
                if (i > 0 && i < 10)
                {
                    pCode = "KM00" + i.ToString();
                }
                else
                {
                    pCode = "KM0" + i.ToString();
                }

                if (!khuyenmai_bll.checkPK(pCode))
                {
                    return pCode;
                }

                i++;
            }
        }
    }
}
