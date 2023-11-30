using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL khachhang_dal = new KhachHangDAL();

        public KhachHangBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG
        public List<KhachHangDTO> getDataKhachHang()
        {
            return khachhang_dal.getDataKhachHang();
        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG THEO MÃ KHÁCH HÀNG
        public List<KhachHangDTO> getDataKhachHangTheoMaKH(string pMaKH)
        {
            return khachhang_dal.getDataKhachHangTheoMaKH(pMaKH);
        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG CÓ ĐIỀU KIỆN
        public List<KhachHangDTO> getDataKhachHangDK(string pMaKH)
        {
            return khachhang_dal.getDataKhachHangDK(pMaKH);
        }

        //------------------ THÊM KHÁCH HÀNG
        public void addKH(KhachHangDTO kh)
        {
            khachhang_dal.addKH(kh);
        }

        //------------------ XÓA KHÁCH HÀNG
        public bool removeKH(string pMaKH)
        {
            return khachhang_dal.removeKH(pMaKH);
        }

        //------------------ SỬA KHÁCH HÀNG
        public void editKH(KhachHangDTO kh)
        {
            khachhang_dal.editKH(kh);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return khachhang_dal.checkPK(pCode);
        }
    }
}
