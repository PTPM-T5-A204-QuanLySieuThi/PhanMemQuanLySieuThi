using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public  class NhaCungCapBLL
    {
        NhaCungCapDAL nhacungcap_dal = new NhaCungCapDAL();

        public NhaCungCapBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> getDataNhaCungCap()
        {
            return nhacungcap_dal.getDataNhaCungCap();
        }

        //------------------ TÌM DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> findDataNhaCungCap(string pValue)
        {
            return nhacungcap_dal.findDataNhaCungCap(pValue);
        }
    }
}
