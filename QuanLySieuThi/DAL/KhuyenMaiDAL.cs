using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhuyenMaiDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public KhuyenMaiDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI
        public List<KhuyenMaiDTO> getDataKhuyenMai()
        {
            var query = from km in qlst.KHUYENMAIs select km;

            var khuyenmais = query.ToList().ConvertAll(nv => new KhuyenMaiDTO()
            {
                makm = nv.MAKM,
                tenkm = nv.TENKM,
                ngaybatdau = (DateTime)nv.NGAYBATDAU,
                ngayketthuc = (DateTime)nv.NGAYKETTHUC,
                sogiam = (int)nv.SOGIAM
            });

            List<KhuyenMaiDTO> lst_km = khuyenmais.ToList();

            return lst_km;
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI THEO MÃ KHUYẾN MÃI
        public List<KhuyenMaiDTO> getDataKhuyenMaiTheoMaKM(string pMaKM)
        {
            var query = from km in qlst.KHUYENMAIs where km.MAKM == pMaKM select km;

            var khuyenmais = query.ToList().ConvertAll(nv => new KhuyenMaiDTO()
            {
                makm = nv.MAKM,
                tenkm = nv.TENKM,
                ngaybatdau = (DateTime)nv.NGAYBATDAU,
                ngayketthuc = (DateTime)nv.NGAYKETTHUC,
                sogiam = (int)nv.SOGIAM
            });

            List<KhuyenMaiDTO> lst_km = khuyenmais.ToList();

            return lst_km;
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI THEO MÃ SẢN PHẨM
        public KhuyenMaiDTO getDataKhuyenMaiTheoMaSP(string pValue)
        {
            var query = from km in qlst.KHUYENMAIs join ctkm in qlst.CHITIETKHUYENMAIs on km.MAKM equals ctkm.MAKM where ctkm.MASP == pValue select km;
           
            var khuyenmais = query.ToList().ConvertAll(nv => new KhuyenMaiDTO()
            {
                makm = nv.MAKM,
                tenkm = nv.TENKM,
                ngaybatdau = (DateTime)nv.NGAYBATDAU,
                ngayketthuc = (DateTime)nv.NGAYKETTHUC,
                sogiam = (int)nv.SOGIAM
            });

            List<KhuyenMaiDTO> lst_km = khuyenmais.ToList();

            KhuyenMaiDTO kmai = lst_km.FirstOrDefault();

            return kmai;
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI CÓ ĐIỀU KIỆN
        public List<KhuyenMaiDTO> getDataKhuyenMaiDK(string pValue)
        {
            var query = from km in qlst.KHUYENMAIs where km.TENKM.Contains(pValue) || km.MAKM.Contains(pValue) select km;

            var khuyenmais = query.ToList().ConvertAll(km => new KhuyenMaiDTO()
            {
                makm = km.MAKM,
                tenkm = km.TENKM,
                ngaybatdau = (DateTime)km.NGAYBATDAU,
                ngayketthuc = (DateTime)km.NGAYKETTHUC,
                sogiam = (int)km.SOGIAM,
            });

            List<KhuyenMaiDTO> lst_km = khuyenmais.ToList();

            return lst_km;
        }

        //------------------ THÊM KHUYẾN MÃI
        public void addKM(KhuyenMaiDTO km)
        {
            KHUYENMAI kms = new KHUYENMAI();

            kms.MAKM = km.makm;
            kms.TENKM = km.tenkm;
            kms.NGAYBATDAU = km.ngaybatdau;
            kms.NGAYKETTHUC = km.ngayketthuc;
            kms.SOGIAM = km.sogiam;

            qlst.KHUYENMAIs.InsertOnSubmit(kms);
            qlst.SubmitChanges();
        }

        //------------------ XÓA KHUYẾN MÃI
        public bool removeKM(string pMaKM)
        {
            KHUYENMAI km = qlst.KHUYENMAIs.Where(t => t.MAKM == pMaKM).FirstOrDefault();
            if (km != null)
            {
                qlst.KHUYENMAIs.DeleteOnSubmit(km);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA KHUYẾN MÃI
        public void editKM(KhuyenMaiDTO km)
        {
            KHUYENMAI kms = qlst.KHUYENMAIs.Where(t => t.MAKM == km.makm).FirstOrDefault();

            kms.MAKM = km.makm;
            kms.TENKM = km.tenkm;
            kms.NGAYBATDAU = km.ngaybatdau;
            kms.NGAYKETTHUC = km.ngayketthuc;
            kms.SOGIAM = km.sogiam;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from km in qlst.KHUYENMAIs where km.MAKM == pCode select km;
            return query.Any();
        }

    }
}
