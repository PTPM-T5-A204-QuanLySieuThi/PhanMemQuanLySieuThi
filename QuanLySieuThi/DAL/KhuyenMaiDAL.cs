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
    }
}
