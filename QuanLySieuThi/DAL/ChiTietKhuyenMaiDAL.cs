using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietKhuyenMaiDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public ChiTietKhuyenMaiDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT KHUYẾN MÃI
        public bool isKhuyenMai(string pValue)
        {
            var query = from ctkm in qlst.CHITIETKHUYENMAIs where ctkm.MASP == pValue select ctkm;
            return query.Any();
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT KHUYẾN MÃI
        public List<ChiTietKhuyenMaiDTO> getDataCTKhuyenMai(string pValue)
        {
            var query = from ctkm in qlst.CHITIETKHUYENMAIs where ctkm.MASP == pValue select ctkm;

            var ctkhuyenmais = query.ToList().ConvertAll(nv => new ChiTietKhuyenMaiDTO()
            {
                makm = nv.MAKM,
                masp = nv.MASP
            });

            List<ChiTietKhuyenMaiDTO> lst_ctkm = ctkhuyenmais.ToList();

            return lst_ctkm;
        }
    }
}
