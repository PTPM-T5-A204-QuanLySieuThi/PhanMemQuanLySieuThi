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

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<SanPhamDTO> getDataSanPhamDK(string pValue)
        {
            return sanpham_dal.getDataSanPhamDK(pValue);
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC THEO LOẠI SẢN PHẨM
        public List<SanPhamDTO> getDataSanPhamCategory(string pValue)
        {
            return sanpham_dal.getDataSanPhamCategory(pValue);
        }
    }
}
