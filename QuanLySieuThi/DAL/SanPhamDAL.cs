using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SanPhamDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public SanPhamDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM
        public List<SanPhamDTO> getDataSanPham()
        {
            var query = from sp in qlst.SANPHAMs select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                anhsanpham = nv.ANHSANPHAM,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                mota = nv.MOTA,
                slton = (int)nv.SLTON,
                manxx = nv.MANXX,
                mancc = nv.MANCC,
                madvt = nv.MADVT,
                mactlsp = nv.MACTLSP
            });

            List<SanPhamDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM THEO MÃ SẢN PHẨM
        public List<SanPhamDTO> getDataSanPhamTheoMaSP(string pMaSP)
        {
            var query = from sp in qlst.SANPHAMs where sp.MASP == pMaSP select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                anhsanpham = nv.ANHSANPHAM,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                mota = nv.MOTA,
                slton = (int)nv.SLTON,
                manxx = nv.MANXX,
                mancc = nv.MANCC,
                madvt = nv.MADVT,
                mactlsp = nv.MACTLSP
            });

            List<SanPhamDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC
        public List<SanPhamLocDTO> getDataSanPhamLoc()
        {
            var query = from sp in qlst.SANPHAMs select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamLocDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                slton = (int)nv.SLTON
            });

            List<SanPhamLocDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<SanPhamDTO> getDataSanPhamDK(string pValue)
        {
            var query = from sp in qlst.SANPHAMs where sp.TENSP.Contains(pValue) || sp.BARCODE.Contains(pValue) select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                anhsanpham = nv.ANHSANPHAM,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                mota = nv.MOTA,
                slton = (int)nv.SLTON,
                manxx = nv.MANXX,
                mancc = nv.MANCC,
                madvt = nv.MADVT,
                mactlsp = nv.MACTLSP
            });

            List<SanPhamDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC CÓ ĐIỀU KIỆN
        public List<SanPhamLocDTO> getDataSanPhamLocDK(string pValue)
        {
            var query = from sp in qlst.SANPHAMs where sp.MASP.Contains(pValue) || sp.TENSP.Contains(pValue) || sp.BARCODE.Contains(pValue) select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamLocDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                slton = (int)nv.SLTON
            });

            List<SanPhamLocDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<SanPhamDTO> getDataSanPhamTheoMaHD(string pValue)
        {
            var query = from sp in qlst.SANPHAMs join cthd in qlst.CHITIETHOADONs on sp.MASP equals cthd.MASP where cthd.MAHD == pValue select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                anhsanpham = nv.ANHSANPHAM,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                mota = nv.MOTA,
                slton = (int)nv.SLTON,
                manxx = nv.MANXX,
                mancc = nv.MANCC,
                madvt = nv.MADVT,
                mactlsp = nv.MACTLSP
            });

            List<SanPhamDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM LỌC THEO LOẠI SẢN PHẨM
        public List<SanPhamDTO> getDataSanPhamCategory(string pValue)
        {
            var query = from sp in qlst.SANPHAMs join ctlsp in qlst.CTLOAISANPHAMs on sp.MACTLSP equals ctlsp.MACTLSP where ctlsp.MALSP == pValue select sp;

            var sanphams = query.ToList().ConvertAll(nv => new SanPhamDTO()
            {
                masp = nv.MASP,
                barcode = nv.BARCODE,
                tensp = nv.TENSP,
                anhsanpham = nv.ANHSANPHAM,
                ngaysx = (DateTime)nv.NGAYSX,
                hansd = (DateTime)nv.HANSD,
                giasp = (decimal)nv.GIASP,
                mota = nv.MOTA,
                slton = (int)nv.SLTON,
                manxx = nv.MANXX,
                mancc = nv.MANCC,
                madvt = nv.MADVT,
                mactlsp = nv.MACTLSP
            });

            List<SanPhamDTO> lst_sp = sanphams.ToList();

            return lst_sp;
        }

        //------------------ LẤY MÃ SẢN PHẨM
        public string getMaSanPham(string pTenSP)
        {
            var query = from sp in qlst.SANPHAMs where sp.TENSP == pTenSP select sp.MASP;
            string pMaSP = query.FirstOrDefault();
            return pMaSP;
        }

        //------------------ CẬP NHẬT SỐ LƯỢNG TỒN
        public void updateSoLuongTon(string pMaSP, int pSoLuong)
        {
            SANPHAM sps = qlst.SANPHAMs.Where(t => t.MASP == pMaSP).FirstOrDefault();

            sps.SLTON -= pSoLuong;

            qlst.SubmitChanges();
        }

        //------------------ THÊM SẢN PHẨM
        public void addSP(SanPhamDTO sp)
        {
            SANPHAM sps = new SANPHAM();

            sps.MASP = sp.masp;
            sps.BARCODE = sp.barcode;
            sps.TENSP = sp.tensp;
            sps.ANHSANPHAM = sp.anhsanpham;
            sps.NGAYSX = sp.ngaysx;
            sps.HANSD = sp.hansd;
            sps.GIASP = sp.giasp;
            sps.MOTA = sp.mota;
            sps.SLTON = sp.slton;
            sps.MANXX = sp.manxx;
            sps.MANCC = sp.mancc;
            sps.MADVT = sp.madvt;
            sps.MACTLSP = sp.mactlsp;

            qlst.SANPHAMs.InsertOnSubmit(sps);
            qlst.SubmitChanges();
        }

        //------------------ XÓA SẢN PHẨM
        public bool removeSP(string pMaSP)
        {
            SANPHAM sp = qlst.SANPHAMs.Where(t => t.MASP == pMaSP).FirstOrDefault();
            if (sp != null)
            {
                qlst.SANPHAMs.DeleteOnSubmit(sp);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA SẢN PHẨM
        public void editSP(SanPhamDTO sp)
        {
            SANPHAM sps = qlst.SANPHAMs.Where(t => t.MASP == sp.masp).FirstOrDefault();

            sps.MASP = sp.masp;
            sps.BARCODE = sp.barcode;
            sps.TENSP = sp.tensp;
            sps.ANHSANPHAM = sp.anhsanpham;
            sps.NGAYSX = sp.ngaysx;
            sps.HANSD = sp.hansd;
            sps.GIASP = sp.giasp;
            sps.MOTA = sp.mota;
            sps.SLTON = sp.slton;
            sps.MANXX = sp.manxx;
            sps.MANCC = sp.mancc;
            sps.MADVT = sp.madvt;
            sps.MACTLSP = sp.mactlsp;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from sp in qlst.SANPHAMs where sp.MASP == pCode select sp;
            return query.Any();
        }

    }
}
