using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public ChiTietHoaDonDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT HÓA ĐƠN
        public List<ChiTietHoaDonDTO> getDataCTHoaDon()
        {
            var query = from cthd in qlst.CHITIETHOADONs select cthd;

            var cthoadons = query.ToList().ConvertAll(nv => new ChiTietHoaDonDTO()
            {
                mahd = nv.MAHD,
                masp = nv.MASP,
                soluong = (int)nv.SOLUONG,
                tongtien = (decimal)nv.TONGTIEN
            });

            List<ChiTietHoaDonDTO> lst_cthd = cthoadons.ToList();

            return lst_cthd;
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT HÓA ĐƠN THEO MÃ HÓA ĐƠN
        public List<ChiTietHoaDonDTO> getDataCTHoaDonTheoHD(string pMaHD)
        {
            var query = from cthd in qlst.CHITIETHOADONs where cthd.MAHD == pMaHD select cthd;

            var cthoadons = query.ToList().ConvertAll(nv => new ChiTietHoaDonDTO()
            {
                mahd = nv.MAHD,
                masp = nv.MASP,
                soluong = (int)nv.SOLUONG,
                tongtien = (decimal)nv.TONGTIEN
            });

            List<ChiTietHoaDonDTO> lst_cthd = cthoadons.ToList();

            return lst_cthd;
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT HÓA ĐƠN THEO MÃ HÓA ĐƠN VÀ MÃ SẢN PHẨM
        public List<ChiTietHoaDonDTO> getDataCTHoaDonTheoMaHD(string pMaHD, string pMaSP)
        {
            var query = from cthd in qlst.CHITIETHOADONs where cthd.MAHD == pMaHD && cthd.MASP == pMaSP select cthd;

            var cthoadons = query.ToList().ConvertAll(nv => new ChiTietHoaDonDTO()
            {
                mahd = nv.MAHD,
                masp = nv.MASP,
                soluong = (int)nv.SOLUONG,
                tongtien = (decimal)nv.TONGTIEN
            });

            List<ChiTietHoaDonDTO> lst_cthd = cthoadons.ToList();

            return lst_cthd;
        }

        //------------------ THÊM CHI TIẾT HÓA ĐƠN
        public void addHD(ChiTietHoaDonDTO cthd)
        {
            CHITIETHOADON cthds = new CHITIETHOADON();

            cthds.MAHD = cthd.mahd;
            cthds.MASP = cthd.masp;
            cthds.SOLUONG = cthd.soluong;
            cthds.TONGTIEN = cthd.tongtien;

            qlst.CHITIETHOADONs.InsertOnSubmit(cthds);
            qlst.SubmitChanges();
        }
    }
}
