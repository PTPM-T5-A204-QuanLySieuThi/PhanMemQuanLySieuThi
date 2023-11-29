using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NuocXuatXuDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public NuocXuatXuDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU NƯỚC XUẤT XỨ
        public List<NuocXuatXuDTO> getDataNuocXuatXu()
        {
            var query = from nxx in qlst.NUOCXUATXUs select nxx;

            var nuocxuatxus = query.ToList().ConvertAll(nxx => new NuocXuatXuDTO()
            {
                manxx = nxx.MANXX,
                tennxx = nxx.TENNXX,
            });

            List<NuocXuatXuDTO> lst_nxx = nuocxuatxus.ToList();

            return lst_nxx;
        }
    }
}
