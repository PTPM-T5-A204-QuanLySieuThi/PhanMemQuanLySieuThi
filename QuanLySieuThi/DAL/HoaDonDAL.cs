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
                tongtien = nv.TONGTIEN,
                ngaylap = nv.NGAYLAP,
                thanhtien = nv.THANHTIEN,
                manv = nv.MANV
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
                tongtien = nv.TONGTIEN,
                ngaylap = nv.NGAYLAP,
                thanhtien = nv.THANHTIEN,
                manv = nv.MANV,
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
                tongtien = nv.TONGTIEN,
                ngaylap = nv.NGAYLAP,
                thanhtien = nv.THANHTIEN,
                manv = nv.MANV,
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ THÊM HÓA ĐƠN
        public void addHD(HoaDonDTO hd)
        {
            HOADON hds = new HOADON();

            hds.MAHD = hd.mahd;
            hds.NGAYLAP = hd.ngaylap;
            hds.TONGTIEN = hd.tongtien;
            hds.THANHTIEN = hd.thanhtien;
            hds.MANV = hd.manv;

            qlst.HOADONs.InsertOnSubmit(hds);
            qlst.SubmitChanges();
        }

        //------------------ ĐẾM SỐ HÓA ĐƠN TRONG NGÀY
        public int countBillDaily()
        {
            DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
            var query = from hd in qlst.HOADONs where hd.NGAYLAP >= dt1 && hd.NGAYLAP < dt2 select hd;
            return query.Count();
        }

        //------------------ TÍNH DOANH THU HÓA ĐƠN TRONG NGÀY
        public decimal calBillDaily()
        {
            try
            {
                DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
                decimal totalAmount = (decimal)qlst.HOADONs.Where(hd => hd.NGAYLAP >= dt1 && hd.NGAYLAP < dt2).Sum(hd => hd.THANHTIEN);
                return totalAmount;
            }
            catch
            {
                return 0;
            }
        }

        //------------------ LẤY DOANH THU THEO THÁNG
        public decimal calBillMonth(int pMonth, int pYear)
        {
            try
            {
                decimal totalAmount = (decimal)qlst.HOADONs.Where(hd => hd.NGAYLAP.HasValue && hd.NGAYLAP.Value.Month == pMonth && hd.NGAYLAP.Value.Year == pYear).Sum(hd => hd.THANHTIEN);
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
