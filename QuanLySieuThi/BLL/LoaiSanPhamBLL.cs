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
    }
}
