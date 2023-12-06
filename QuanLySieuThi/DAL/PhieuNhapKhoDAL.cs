using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuNhapKhoDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public PhieuNhapKhoDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU PHIẾU NHẬP KHO
        public List<PhieuNhapKhoDTO> getDataPhieuNhapKho()
        {
            var query = from pnk in qlst.PHIEUNHAPKHOs select pnk;

            var phieunhapkhos = query.ToList().ConvertAll(pnk => new PhieuNhapKhoDTO()
            {
                maphieu = pnk.MAPHIEU,
                ngaynhap = (DateTime)pnk.NGAYNHAP,
                masp = pnk.MASP,
                soluong = (int)pnk.SOLUONG,
                tongtien = (decimal)pnk.TONGTIEN,
                ghichu = pnk.GHICHU
            });

            List<PhieuNhapKhoDTO> lst_pnk = phieunhapkhos.ToList();

            return lst_pnk;
        }

        //------------------ LẤY DỮ LIỆU PHIẾU NHẬP KHO CÓ ĐIỀU KIỆN
        public List<PhieuNhapKhoDTO> getDataPhieuNhapKhoDK(string pMaPhieu)
        {
            var query = from pnk in qlst.PHIEUNHAPKHOs where pnk.MAPHIEU == pMaPhieu select pnk;

            var phieunhapkhos = query.ToList().ConvertAll(pnk => new PhieuNhapKhoDTO()
            {
                maphieu = pnk.MAPHIEU,
                ngaynhap = (DateTime)pnk.NGAYNHAP,
                masp = pnk.MASP,
                soluong = (int)pnk.SOLUONG,
                tongtien = (decimal)pnk.TONGTIEN,
                ghichu = pnk.GHICHU
            });

            List<PhieuNhapKhoDTO> lst_pnk = phieunhapkhos.ToList();

            return lst_pnk;
        }

        //------------------ THÊM PHIẾU NHẬP KHO
        public void addPNK(PhieuNhapKhoDTO pnk)
        {
            PHIEUNHAPKHO pnks = new PHIEUNHAPKHO();

            pnks.MAPHIEU = pnk.maphieu;
            pnks.NGAYNHAP = pnk.ngaynhap;
            pnks.MASP = pnk.masp;
            pnks.SOLUONG = pnk.soluong;
            pnks.TONGTIEN = pnk.tongtien;
            pnks.GHICHU = pnk.ghichu;

            qlst.PHIEUNHAPKHOs.InsertOnSubmit(pnks);
            qlst.SubmitChanges();
        }

        //------------------ XÓA PHIẾU NHẬP KHO
        public bool removePNK(string pMaPhieu)
        {
            PHIEUNHAPKHO pnk = qlst.PHIEUNHAPKHOs.Where(t => t.MAPHIEU == pMaPhieu).FirstOrDefault();
            if (pnk != null)
            {
                qlst.PHIEUNHAPKHOs.DeleteOnSubmit(pnk);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA PHIẾU NHẬP KHO
        public void editPNK(PhieuNhapKhoDTO pnk)
        {
            PHIEUNHAPKHO pnks = qlst.PHIEUNHAPKHOs.Where(t => t.MAPHIEU == pnk.maphieu).FirstOrDefault();

            pnks.MAPHIEU = pnk.maphieu;
            pnks.NGAYNHAP = pnk.ngaynhap;
            pnks.MASP = pnk.masp;
            pnks.SOLUONG = pnk.soluong;
            pnks.TONGTIEN = pnk.tongtien;
            pnks.GHICHU = pnk.ghichu;

            qlst.SubmitChanges();
        }


        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from pnk in qlst.PHIEUNHAPKHOs where pnk.MAPHIEU == pCode select pnk;
            return query.Any();
        }
    }
}
