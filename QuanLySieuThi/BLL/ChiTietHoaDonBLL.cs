using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        ChiTietHoaDonDAL chitiethoadon_dal = new ChiTietHoaDonDAL();

        public ChiTietHoaDonBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT HÓA ĐƠN
        public List<ChiTietHoaDonDTO> getDataCTHoaDon()
        {
            return chitiethoadon_dal.getDataCTHoaDon();
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT HÓA ĐƠN THEO MÃ HÓA ĐƠN VÀ MÃ SẢN PHẨM
        public List<ChiTietHoaDonDTO> getDataCTHoaDonTheoMaHD(string pMaHD, string pMaSP)
        {
            return chitiethoadon_dal.getDataCTHoaDonTheoMaHD(pMaHD, pMaSP);
        }

        //------------------ THÊM CHI TIẾT HÓA ĐƠN
        public void addHD(ChiTietHoaDonDTO cthd)
        {
            chitiethoadon_dal.addHD(cthd);
        }
    }
}
