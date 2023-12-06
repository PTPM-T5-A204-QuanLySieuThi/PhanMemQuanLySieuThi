using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class HoaDonDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public HoaDonDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDon()
        {
            var query = from hd in qlst.HOADONs select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                makh = nv.MAKH,
                manv = nv.MANV,
                thanhtien = (decimal)nv.THANHTIEN,
                ngaylap = (DateTime)nv.NGAYLAP,
                trangthai = (bool)nv.TRANGTHAI
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN ĐÃ THANH TOÁN
        public List<HoaDonDTO> getDataHoaDonDaThanhToan()
        {
            var query = from hd in qlst.HOADONs where hd.TRANGTHAI == true select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                makh = nv.MAKH,
                manv = nv.MANV,
                thanhtien = (decimal)nv.THANHTIEN,
                ngaylap = (DateTime)nv.NGAYLAP,
                trangthai = (bool)nv.TRANGTHAI
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ TÌM DỮ LIỆU HÓA ĐƠN
        public List<HoaDonDTO> findDataHoaDon(string pMaHD)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD.Contains(pMaHD) || hd.MANV.Contains(pMaHD) select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                makh = nv.MAKH,
                manv = nv.MANV,
                thanhtien = (decimal)nv.THANHTIEN,
                ngaylap = (DateTime)nv.NGAYLAP,
                trangthai = (bool)nv.TRANGTHAI
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN THEO MÃ HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDonTheoMaHD(string pMaHD)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD == pMaHD select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                makh = nv.MAKH,
                manv = nv.MANV,
                thanhtien = (decimal)nv.THANHTIEN,
                ngaylap = (DateTime)nv.NGAYLAP,
                trangthai = (bool)nv.TRANGTHAI
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ THÊM HÓA ĐƠN
        public void addHD(HoaDonDTO hd)
        {
            HOADON hds = new HOADON();

            hds.MAHD = hd.mahd;
            hds.MANV = hd.manv;
            hds.MAKH = hd.makh;
            hds.NGAYLAP = hd.ngaylap;
            hds.THANHTIEN = hd.thanhtien;
            hds.TRANGTHAI = hd.trangthai;

            qlst.HOADONs.InsertOnSubmit(hds);
            qlst.SubmitChanges();
        }

        //------------------ XÓA HÓA ĐƠN
        public bool removeHD(string pMaHD)
        {
            HOADON hd = qlst.HOADONs.Where(t => t.MAHD == pMaHD).FirstOrDefault();
            if (hd != null)
            {
                qlst.HOADONs.DeleteOnSubmit(hd);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA HÓA ĐƠN
        public void editHD(HoaDonDTO hd)
        {
            HOADON hds = qlst.HOADONs.Where(t => t.MAHD == hd.mahd).FirstOrDefault();

            hds.MAHD = hd.mahd;
            hds.MANV = hd.manv;
            hds.MAKH = hd.makh;
            hds.NGAYLAP = hd.ngaylap;
            hds.THANHTIEN = hd.thanhtien;
            hds.TRANGTHAI = hd.trangthai;

            qlst.SubmitChanges();
        }

        //------------------ TÌM HÓA ĐƠN THEO NGÀY THÁNG NĂM
        public List<HoaDonDTO> findBillOnDate(DateTime pValue)
        {
            var query = from hd in qlst.HOADONs where hd.NGAYLAP >= pValue && hd.NGAYLAP < pValue.AddDays(1) select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                makh = nv.MAKH,
                manv = nv.MANV,
                thanhtien = (decimal)nv.THANHTIEN,
                ngaylap = (DateTime)nv.NGAYLAP,
                trangthai = (bool)nv.TRANGTHAI
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ ĐẾM SỐ HÓA ĐƠN TRONG NGÀY
        public int countBillDaily()
        {
            DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
            var query = from hd in qlst.HOADONs where hd.NGAYLAP >= dt1 && hd.NGAYLAP < dt2 && hd.TRANGTHAI == true select hd;
            return query.Count();
        }

        //------------------ TÍNH DOANH THU HÓA ĐƠN TRONG NGÀY
        public decimal calBillDaily()
        {
            try
            {
                DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
                decimal totalAmount = (decimal)qlst.HOADONs.Where(hd => hd.NGAYLAP >= dt1 && hd.NGAYLAP < dt2 && hd.TRANGTHAI == true).Sum(hd => hd.THANHTIEN);
                return totalAmount;
            }
            catch
            {
                return 0;
            }
        }

        //------------------ KIỂM TRA HÓA ĐƠN ĐÃ THANH TOÁN CHƯA
        public bool checkBillConfirm(string pMaHD)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD == pMaHD && hd.TRANGTHAI == true select hd;
            return query.Any();
        }

        //------------------ LẤY DOANH THU THEO THÁNG
        public decimal calBillMonth(int pMonth, int pYear)
        {
            try
            {
                decimal totalAmount = (decimal)qlst.HOADONs.Where(hd => hd.NGAYLAP.HasValue && hd.NGAYLAP.Value.Month == pMonth && hd.NGAYLAP.Value.Year == pYear && hd.TRANGTHAI == true).Sum(hd => hd.THANHTIEN);
                return totalAmount;
            }
            catch
            {
                return 0;
            }
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD == pCode select hd;
            return query.Any();
        }

    }
}
