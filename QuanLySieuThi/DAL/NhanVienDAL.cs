using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN THEO MÃ NHÂN VIÊN
        public List<NhanVienDTO> getDataNhanVienTheoMaNV(string pMaNV)
        {
            var query = from nv in qlst.NHANVIENs where nv.MANV == pMaNV select nv;

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

        //------------------ LẤY TÊN TÀI KHOẢN
        public string getMaTaiKhoan(string pRole, string pPass)
        {
            var query = from nv in qlst.NHANVIENs join tk in qlst.TAIKHOANs on nv.MATK equals tk.MATK join tc in qlst.QUYENTRUYCAPs on tk.MAQTC equals tc.MAQTC where tc.TENQTC == pRole && tk.MATKHAU == pPass select nv.MATK;

            string pMaTK = query.FirstOrDefault();
            return pMaTK;
        }

        //------------------ THÊM NHÂN VIÊN
        public void addNV(NhanVienDTO nv)
        {
            NHANVIEN nvs = new NHANVIEN();

            nvs.MANV = nv.manv;
            nvs.HOTEN = nv.hoten;
            nvs.NGAYSINH = nv.ngaysinh;
            nvs.ANHDAIDIEN = nv.anhdaidien;
            nvs.GIOITINH = nv.gioitinh;
            nvs.DIACHI = nv.diachi;
            nvs.SODIENTHOAI = nv.sodienthoai;
            nvs.EMAIL = nv.email;
            nvs.MATK = nv.matk;

            qlst.NHANVIENs.InsertOnSubmit(nvs);
            qlst.SubmitChanges();
        }

        //------------------ XÓA NHÂN VIÊN
        public bool removeNV(string pMaNV)
        {
            NHANVIEN nv = qlst.NHANVIENs.Where(t => t.MANV == pMaNV).FirstOrDefault();
            if (nv != null)
            {
                qlst.NHANVIENs.DeleteOnSubmit(nv);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA NHÂN VIÊN
        public void editNV(NhanVienDTO nv)
        {
            NHANVIEN nvs = qlst.NHANVIENs.Where(t => t.MANV == nv.manv).FirstOrDefault();

            nvs.MANV = nv.manv;
            nvs.HOTEN = nv.hoten;
            nvs.NGAYSINH = nv.ngaysinh;
            nvs.ANHDAIDIEN = nv.anhdaidien;
            nvs.GIOITINH = nv.gioitinh;
            nvs.DIACHI = nv.diachi;
            nvs.SODIENTHOAI = nv.sodienthoai;
            nvs.EMAIL = nv.email;
            nvs.MATK = nv.matk;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from nv in qlst.NHANVIENs where nv.MANV == pCode select nv;
            return query.Any();
        }

    }
}
