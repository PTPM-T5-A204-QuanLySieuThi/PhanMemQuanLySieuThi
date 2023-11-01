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
    }
}
