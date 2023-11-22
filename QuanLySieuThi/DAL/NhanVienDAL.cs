using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public NhanVienDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN
        public List<NhanVienDTO> getDataNhanVien()
        {
            var query = from nv in qlst.NHANVIENs select nv;

            var nhanviens = query.ToList().ConvertAll(nv => new NhanVienDTO()
            {
                manv = nv.MANV,
                hoten = nv.HOTEN,
                anhdaidien = nv.ANHDAIDIEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                gioitinh = nv.GIOITINH,
                diachi = nv.DIACHI,
                sodienthoai = nv.SODIENTHOAI,
                email = nv.EMAIL,
                matk = nv.MATK
            });

            List<NhanVienDTO> lst_nv = nhanviens.ToList();

            return lst_nv;
        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN BÁN HÀNG
        public List<NhanVienDTO> getDataNhanVienBanHang()
        {
            var query = from nv in qlst.NHANVIENs where nv.MATK == "TK002" select nv;

            var nhanviens = query.ToList().ConvertAll(nv => new NhanVienDTO()
            {
                manv = nv.MANV,
                hoten = nv.HOTEN,
                anhdaidien = nv.ANHDAIDIEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                gioitinh = nv.GIOITINH,
                diachi = nv.DIACHI,
                sodienthoai = nv.SODIENTHOAI,
                email = nv.EMAIL,
                matk = nv.MATK
            });

            List<NhanVienDTO> lst_nv = nhanviens.ToList();

            return lst_nv;
        }

    }
}
