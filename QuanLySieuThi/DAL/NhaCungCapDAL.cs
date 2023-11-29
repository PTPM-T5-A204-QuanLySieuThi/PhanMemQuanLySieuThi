using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCapDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public NhaCungCapDAL()
        {

        }


        //------------------ LẤY DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> getDataNhaCungCap()
        {
            var query = from ncc in qlst.NHACUNGCAPs select ncc;

            var nhacungcaps = query.ToList().ConvertAll(ncc => new NhaCungCapDTO()
            {
                mancc = ncc.MANCC,
                tenncc = ncc.TENNCC,
                diachi = ncc.DIACHI,
                sodienthoai = ncc.SODIENTHOAI
            });

            List<NhaCungCapDTO> lst_ncc = nhacungcaps.ToList();

            return lst_ncc;
        }

        //------------------ TÌM DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> findDataNhaCungCap(string pValue)
        {
            var query = from ncc in qlst.NHACUNGCAPs where ncc.MANCC.Contains(pValue) || ncc.TENNCC.Contains(pValue) select ncc;

            var nhacungcaps = query.ToList().ConvertAll(ncc => new NhaCungCapDTO()
            {
                mancc = ncc.MANCC,
                tenncc = ncc.TENNCC,
                diachi = ncc.DIACHI,
                sodienthoai = ncc.SODIENTHOAI
            });

            List<NhaCungCapDTO> lst_ncc = nhacungcaps.ToList();

            return lst_ncc;
        }
    }
}
