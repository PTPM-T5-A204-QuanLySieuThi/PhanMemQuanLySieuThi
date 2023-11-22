using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietKhuyenMaiBLL
    {
        ChiTietKhuyenMaiDAL chitietkhuyenmai_dal = new ChiTietKhuyenMaiDAL();

        public ChiTietKhuyenMaiBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT KHUYẾN MÃI
        public bool isKhuyenMai(string pValue)
        {
            return chitietkhuyenmai_dal.isKhuyenMai(pValue);
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT KHUYẾN MÃI
        public List<ChiTietKhuyenMaiDTO> getDataCTKhuyenMai(string pValue)
        {
            return chitietkhuyenmai_dal.getDataCTKhuyenMai(pValue);
        }
    }
}
