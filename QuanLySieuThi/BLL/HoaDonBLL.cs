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

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN ĐÃ THANH TOÁN
        public List<HoaDonDTO> getDataHoaDonDaThanhToan()
        {
            return hoadon_dal.getDataHoaDonDaThanhToan();
        }

        //------------------ TÌM DỮ LIỆU HÓA ĐƠN
        public List<HoaDonDTO> findDataHoaDon(string pMaHD)
        {
            return hoadon_dal.findDataHoaDon(pMaHD);
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

        //------------------ XÓA HÓA ĐƠN
        public bool removeHD(string pMaHD)
        {
            return hoadon_dal.removeHD(pMaHD);
        }

        //------------------ SỬA HÓA ĐƠN
        public void editHD(HoaDonDTO hd)
        {
            hoadon_dal.editHD(hd);
        }

        //------------------ ĐẾM SỐ HÓA ĐƠN TRONG NGÀY
        public int countBillDaily()
        {
            return hoadon_dal.countBillDaily();
        }


        //------------------ KIỂM TRA HÓA ĐƠN ĐÃ THANH TOÁN CHƯA
        public bool checkBillConfirm(string pMaHD)
        {
            return hoadon_dal.checkBillConfirm(pMaHD);
        }

        //------------------ TÍNH DOANH THU HÓA ĐƠN TRONG NGÀY
        public decimal calBillDaily()
        {
            return hoadon_dal.calBillDaily();
        }

        //------------------ LẤY DOANH THU THEO THÁNG
        public decimal calBillMonth(int pMonth,int pYear)
        {
            return hoadon_dal.calBillMonth(pMonth, pYear);
        }


        //------------------ TÌM HÓA ĐƠN THEO NGÀY THÁNG NĂM
        public List<HoaDonDTO> findBillOnDate(DateTime pValue)
        {
            return hoadon_dal.findBillOnDate(pValue);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return hoadon_dal.checkPK(pCode);
        }
    }
}
