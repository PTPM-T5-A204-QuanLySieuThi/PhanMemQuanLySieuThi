using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTLoaiSanPhamDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public CTLoaiSanPhamDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT LOẠI SẢN PHẨM
        public List<CTLoaiSanPhamDTO> getDataCTLoaiSanPham()
        {
            var query = from ctlsp in qlst.CTLOAISANPHAMs select ctlsp;

            var ctloaisanphams = query.ToList().ConvertAll(ctlsp => new CTLoaiSanPhamDTO()
            {
                mactlsp = ctlsp.MACTLSP,
                tenctlsp = ctlsp.TENCTLSP,
                malsp = ctlsp.MALSP
            });

            List<CTLoaiSanPhamDTO> lst_ctlsp = ctloaisanphams.ToList();

            return lst_ctlsp;
        }

        //------------------ LẤY TÊN CHI TIẾT LOẠI SẢN PHẨM
        public string getTenCTLoaiChiTiet(string pMaSP)
        {
            var query = from ctlsp in qlst.CTLOAISANPHAMs join sp in qlst.SANPHAMs on ctlsp.MACTLSP equals sp.MACTLSP where sp.MASP == pMaSP select ctlsp.TENCTLSP;

            return query.FirstOrDefault();
        }
    }
}
