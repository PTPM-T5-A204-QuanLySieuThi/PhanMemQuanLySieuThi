using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class VoucherBLL
    {
        VoucherDAL voucher_dal = new VoucherDAL();

        public VoucherBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU VOUCHER
        public List<VoucherDTO> getDataVoucher()
        {
            return voucher_dal.getDataVoucher();
        }

        //------------------ LẤY DỮ LIỆU VOUCHER THEO MÃ VOURCHER
        public List<VoucherDTO> getDataVoucherTheoMaVor(string pMaVor)
        {
            return voucher_dal.getDataVoucherTheoMaVor(pMaVor);
        }

        //------------------ LẤY DỮ LIỆU VOUCHER CÓ ĐIỀU KIỆN
        public List<VoucherDTO> getDataVoucherDK(string pValue)
        {
            return voucher_dal.getDataVoucherDK(pValue);
        }

        //------------------ THÊM VOUCHER
        public void addVOR(VoucherDTO vor)
        {
            voucher_dal.addVOR(vor);
        }

        //------------------ XÓA VOUCHER
        public bool removeVOR(string pMaVOR)
        {
            return voucher_dal.removeVOR(pMaVOR);
        }

        //------------------ SỬA VOUCHER
        public void editVOR(VoucherDTO vor)
        {
            voucher_dal.editVOR(vor);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return voucher_dal.checkPK(pCode);
        }
    }
}
