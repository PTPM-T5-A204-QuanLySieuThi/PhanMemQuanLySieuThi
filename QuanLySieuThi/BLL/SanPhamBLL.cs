using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sanpham_dal = new SanPhamDAL();

        //------------------ LẤY DỮ LIỆU SẢN PHẨM
        public List<SanPhamDTO> getDataSanPham()
        {
            return sanpham_dal.getDataSanPham();
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM THEO MÃ SẢN PHẨM
        public List<SanPhamDTO> getDataSanPhamTheoMaSP(string pMaSP)
        {
            return sanpham_dal.getDataSanPhamTheoMaSP(pMaSP);
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC
        public List<SanPhamLocDTO> getDataSanPhamLoc()
        {
            return sanpham_dal.getDataSanPhamLoc();
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<SanPhamDTO> getDataSanPhamDK(string pValue)
        {
            return sanpham_dal.getDataSanPhamDK(pValue);
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC CÓ ĐIỀU KIỆN
        public List<SanPhamLocDTO> getDataSanPhamLocDK(string pValue)
        {
            return sanpham_dal.getDataSanPhamLocDK(pValue);
        }


        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<SanPhamDTO> getDataSanPhamTheoMaHD(string pValue)
        {
            return sanpham_dal.getDataSanPhamTheoMaHD(pValue);
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC THEO LOẠI SẢN PHẨM
        public List<SanPhamDTO> getDataSanPhamCategory(string pValue)
        {
            return sanpham_dal.getDataSanPhamCategory(pValue);
        }

        //------------------ LẤY MÃ SẢN PHẨM
        public string getMaSanPham(string pTenSP)
        {
            return sanpham_dal.getMaSanPham(pTenSP);
        }

        //------------------ CẬP NHẬT SỐ LƯỢNG TỒN
        public void updateSoLuongTon(string pMaSP, int pSoLuong)
        {
            sanpham_dal.updateSoLuongTon(pMaSP, pSoLuong);
        }

        //------------------ THÊM SẢN PHẨM
        public void addSP(SanPhamDTO sp)
        {
            sanpham_dal.addSP(sp);
        }

        //------------------ XÓA SẢN PHẨM
        public bool removeSP(string pMaSP)
        {
            return sanpham_dal.removeSP(pMaSP);
        }

        //------------------ SỬA SẢN PHẨM
        public void editSP(SanPhamDTO sp)
        {
            sanpham_dal.editSP(sp);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return sanpham_dal.checkPK(pCode);
        }
    }
}
