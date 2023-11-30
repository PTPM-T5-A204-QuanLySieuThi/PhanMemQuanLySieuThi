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

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN THEO MÃ NHÂN VIÊN
        public List<NhanVienDTO> getDataNhanVienTheoMaNV(string pMaNV)
        {
            return nhanvien_dal.getDataNhanVienTheoMaNV(pMaNV);
        }

        //------------------ LẤY DỮ LIỆU NHÂN VIÊN BÁN HÀNG
        public List<NhanVienDTO> getListNhanVienBanHang()
        {
            return nhanvien_dal.getDataNhanVienBanHang();
        }

        //------------------ LẤY TÊN TÀI KHOẢN
        public string getMaTaiKhoan(string pRole, string pPass)
        {
            return nhanvien_dal.getMaTaiKhoan(pRole, pPass);
        }

        //------------------ THÊM NHÂN VIÊN
        public void addNV(NhanVienDTO nv)
        {
            nhanvien_dal.addNV(nv);
        }

        //------------------ XÓA NHÂN VIÊN
        public bool removeNV(string pMaNV)
        {
            return nhanvien_dal.removeNV(pMaNV);
        }

        //------------------ SỬA NHÂN VIÊN
        public void editNV(NhanVienDTO nv)
        {
            nhanvien_dal.editNV(nv);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return nhanvien_dal.checkPK(pCode);
        }

    }
}
