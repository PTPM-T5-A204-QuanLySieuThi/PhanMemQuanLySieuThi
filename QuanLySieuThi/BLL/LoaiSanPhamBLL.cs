using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoaiSanPhamBLL
    {
        LoaiSanPhamDAL loaisanpham_dal = new LoaiSanPhamDAL();

        public LoaiSanPhamBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN
        public List<LoaiSanPhamDTO> getDataLoaiSanPham()
        {
            return loaisanpham_dal.getDataLoaiSanPham();
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<LoaiSanPhamDTO> getDataLoaiSanPhamDK(string pValue)
        {
            return loaisanpham_dal.getDataLoaiSanPhamDK(pValue);
        }

        //------------------ THÊM LOẠI SẢN PHẨM
        public void addLSP(LoaiSanPhamDTO lsp)
        {
            loaisanpham_dal.addLSP(lsp);
        }

        //------------------ XÓA LOẠI SẢN PHẨM
        public bool removeLSP(string pMaLSP)
        {
            return loaisanpham_dal.removeLSP(pMaLSP);
        }

        //------------------ SỬA LOẠI SẢN PHẨM
        public void editLSP(LoaiSanPhamDTO lsp)
        {
            loaisanpham_dal.editLSP(lsp);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return loaisanpham_dal.checkPK(pCode);
        }
    }
}
