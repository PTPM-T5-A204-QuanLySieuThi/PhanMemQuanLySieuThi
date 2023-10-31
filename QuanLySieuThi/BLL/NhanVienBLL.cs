using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nhanvien_dal = new NhanVienDAL();

        public NhanVienBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN
        public List<NhanVienDTO> getListNhanVien()
        {
            return nhanvien_dal.getDataNhanVien();
        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN BÁN HÀNG
        public List<NhanVienDTO> getListNhanVienBanHang()
        {
            return nhanvien_dal.getDataNhanVienBanHang();
        }

    }
}
