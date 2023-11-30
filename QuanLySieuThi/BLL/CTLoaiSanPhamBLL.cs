using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CTLoaiSanPhamBLL
    {
        CTLoaiSanPhamDAL ctloaisanpham_dal = new CTLoaiSanPhamDAL();

        public CTLoaiSanPhamBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU NƯỚC XUẤT XỨ
        public List<CTLoaiSanPhamDTO> getDataCTLoaiSanPham()
        {
            return ctloaisanpham_dal.getDataCTLoaiSanPham();
        }

        //------------------ LẤY TÊN CHI TIẾT LOẠI SẢN PHẨM
        public string getTenCTLoaiChiTiet(string pMaSP)
        {
            return ctloaisanpham_dal.getTenCTLoaiChiTiet(pMaSP);
        }
    }
}
