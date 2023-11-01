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
    }
}
