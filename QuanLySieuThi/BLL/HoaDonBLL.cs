using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL hoadon_dal = new HoaDonDAL();

        public HoaDonBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDon()
        {
            return hoadon_dal.getDataHoaDon();
        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN THEO MÃ HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDonTheoMaHD(string pMaHD)
        {
            return hoadon_dal.getDataHoaDonTheoMaHD(pMaHD);
        }

        //------------------ THÊM HÓA ĐƠN
        public void addHD(HoaDonDTO hd)
        {
            hoadon_dal.addHD(hd);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return hoadon_dal.checkPK(pCode);
        }
    }
}
