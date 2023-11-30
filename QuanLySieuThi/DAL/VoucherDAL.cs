using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VoucherDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public VoucherDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU VOUCHER
        public List<VoucherDTO> getDataVoucher()
        {
            var query = from vor in qlst.VOUCHERs select vor;

            var vouchers = query.ToList().ConvertAll(vor => new VoucherDTO()
            {
                mavor = vor.MAVOR,
                tenvor = vor.TENVOR,
                conhan = (bool)vor.CONHAN,
                sogiam = vor.SOGIAM,
                dieukien = vor.DIEUKIEN
            });

            List<VoucherDTO> lst_vor = vouchers.ToList();

            return lst_vor;
        }

        //------------------ LẤY DỮ LIỆU VOUCHER THEO MÃ VOURCHER
        public List<VoucherDTO> getDataVoucherTheoMaVor(string pMaVor)
        {
            var query = from vor in qlst.VOUCHERs where vor.MAVOR == pMaVor select vor;

            var vouchers = query.ToList().ConvertAll(vor => new VoucherDTO()
            {
                mavor = vor.MAVOR,
                tenvor = vor.TENVOR,
                conhan = (bool)vor.CONHAN,
                sogiam = vor.SOGIAM,
                dieukien = vor.DIEUKIEN
            });

            List<VoucherDTO> lst_vor = vouchers.ToList();

            return lst_vor;
        }

        //------------------ LẤY DỮ LIỆU VOUCHER CÓ ĐIỀU KIỆN
        public List<VoucherDTO> getDataVoucherDK(string pValue)
        {
            var query = from vor in qlst.VOUCHERs where vor.MAVOR.Contains(pValue) select vor;

            var vouchers = query.ToList().ConvertAll(vor => new VoucherDTO()
            {
                mavor = vor.MAVOR,
                tenvor = vor.TENVOR,
                conhan = (bool)vor.CONHAN,
                sogiam = vor.SOGIAM,
                dieukien = vor.DIEUKIEN,
            });

            List<VoucherDTO> lst_lsp = vouchers.ToList();

            return lst_lsp;
        }

        //------------------ THÊM VOUCHER
        public void addVOR(VoucherDTO vor)
        {
            VOUCHER vors = new VOUCHER();

            vors.MAVOR = vor.mavor;
            vors.TENVOR = vor.tenvor;
            vors.CONHAN = vor.conhan;
            vors.SOGIAM = vor.sogiam;
            vors.DIEUKIEN = vor.dieukien;

            qlst.VOUCHERs.InsertOnSubmit(vors);
            qlst.SubmitChanges();
        }

        //------------------ XÓA VOUCHER
        public bool removeVOR(string pMaVOR)
        {
            VOUCHER vors = qlst.VOUCHERs.Where(t => t.MAVOR == pMaVOR).FirstOrDefault();
            if (vors != null)
            {
                qlst.VOUCHERs.DeleteOnSubmit(vors);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA VOUCHER
        public void editVOR(VoucherDTO vor)
        {
            VOUCHER vors = qlst.VOUCHERs.Where(t => t.MAVOR == vor.mavor).FirstOrDefault();

            vors.MAVOR = vor.mavor;
            vors.TENVOR = vor.tenvor;
            vors.CONHAN = vor.conhan;
            vors.SOGIAM = vor.sogiam;
            vors.DIEUKIEN = vor.dieukien;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from vor in qlst.VOUCHERs where vor.MAVOR == pCode select vor;
            return query.Any();
        }

    }
}
