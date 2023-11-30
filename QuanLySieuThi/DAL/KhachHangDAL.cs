using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public KhachHangDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG
        public List<KhachHangDTO> getDataKhachHang()
        {
            var query = from kh in qlst.KHACHHANGs select kh;

            var khachhangs = query.ToList().ConvertAll(kh => new KhachHangDTO()
            {
                makh = kh.MAKH,
                hoten = kh.HOTEN,
                anhdaidien = kh.ANHDAIDIEN,
                ngaysinh = (DateTime)kh.NGAYSINH,
                gioitinh = kh.GIOITINH,
                diachi = kh.DIACHI,
                sodienthoai = kh.SODIENTHOAI,
                matkhau = kh.MATKHAU,
                email = kh.EMAIL,
                tinhthanh = kh.TINHTHANH,
                diemtichluy = (decimal)kh.DIEMTICHLUY
            });

            List<KhachHangDTO> lst_kh = khachhangs.ToList();

            return lst_kh;
        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG THEO MÃ KHÁCH HÀNG
        public List<KhachHangDTO> getDataKhachHangTheoMaKH(string pMaKH)
        {
            var query = from kh in qlst.KHACHHANGs where kh.MAKH.Contains(pMaKH) || kh.HOTEN.Contains(pMaKH) || kh.SODIENTHOAI.Contains(pMaKH) select kh;

            var khachhangs = query.ToList().ConvertAll(kh => new KhachHangDTO()
            {
                makh = kh.MAKH,
                hoten = kh.HOTEN,
                anhdaidien = kh.ANHDAIDIEN,
                ngaysinh = (DateTime)kh.NGAYSINH,
                gioitinh = kh.GIOITINH,
                diachi = kh.DIACHI,
                sodienthoai = kh.SODIENTHOAI,
                matkhau = kh.MATKHAU,
                email = kh.EMAIL,
                tinhthanh = kh.TINHTHANH,
                diemtichluy = (decimal)kh.DIEMTICHLUY
            });

            List<KhachHangDTO> lst_kh = khachhangs.ToList();

            return lst_kh;
        }

        //------------------ LẤY DỮ LIỆU KHÁCH HÀNG CÓ ĐIỀU KIỆN
        public List<KhachHangDTO> getDataKhachHangDK(string pMaKH)
        {
            var query = from kh in qlst.KHACHHANGs where kh.MAKH == pMaKH select kh;

            var khachhangs = query.ToList().ConvertAll(kh => new KhachHangDTO()
            {
                makh = kh.MAKH,
                hoten = kh.HOTEN,
                anhdaidien = kh.ANHDAIDIEN,
                ngaysinh = (DateTime)kh.NGAYSINH,
                gioitinh = kh.GIOITINH,
                diachi = kh.DIACHI,
                sodienthoai = kh.SODIENTHOAI,
                matkhau = kh.MATKHAU,
                email = kh.EMAIL,
                tinhthanh = kh.TINHTHANH,
                diemtichluy = (decimal)kh.DIEMTICHLUY
            });

            List<KhachHangDTO> lst_kh = khachhangs.ToList();

            return lst_kh;
        }

        //------------------ THÊM KHÁCH HÀNG
        public void addKH(KhachHangDTO kh)
        {
            KHACHHANG khs = new KHACHHANG();

            khs.MAKH = kh.makh;
            khs.HOTEN = kh.hoten;
            khs.NGAYSINH = kh.ngaysinh;
            khs.ANHDAIDIEN = kh.anhdaidien;
            khs.GIOITINH = kh.gioitinh;
            khs.DIACHI = kh.diachi;
            khs.SODIENTHOAI = kh.sodienthoai;
            khs.MATKHAU = kh.email;
            khs.EMAIL = kh.email;
            khs.TINHTHANH = kh.tinhthanh;
            khs.DIEMTICHLUY = kh.diemtichluy;

            qlst.KHACHHANGs.InsertOnSubmit(khs);
            qlst.SubmitChanges();
        }

        //------------------ XÓA KHÁCH HÀNG
        public bool removeKH(string pMaKH)
        {
            KHACHHANG kh = qlst.KHACHHANGs.Where(t => t.MAKH == pMaKH).FirstOrDefault();
            if (kh != null)
            {
                qlst.KHACHHANGs.DeleteOnSubmit(kh);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA KHÁCH HÀNG
        public void editKH(KhachHangDTO kh)
        {
            KHACHHANG khs = qlst.KHACHHANGs.Where(t => t.MAKH == kh.makh).FirstOrDefault();

            khs.MAKH = kh.makh;
            khs.HOTEN = kh.hoten;
            khs.NGAYSINH = kh.ngaysinh;
            khs.ANHDAIDIEN = kh.anhdaidien;
            khs.GIOITINH = kh.gioitinh;
            khs.DIACHI = kh.diachi;
            khs.SODIENTHOAI = kh.sodienthoai;
            khs.MATKHAU = kh.email;
            khs.EMAIL = kh.email;
            khs.TINHTHANH = kh.tinhthanh;
            khs.DIEMTICHLUY = kh.diemtichluy;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from kh in qlst.KHACHHANGs where kh.MAKH == pCode select kh;
            return query.Any();
        }
    }
}
