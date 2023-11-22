using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KhuyenMaiBLL
    {
        KhuyenMaiDAL khuyenmai_dal = new KhuyenMaiDAL();

        public KhuyenMaiBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI
        public List<KhuyenMaiDTO> getDataKhuyenMai()
        {
            return khuyenmai_dal.getDataKhuyenMai();
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI THEO MÃ SẢN PHẨM
        public KhuyenMaiDTO getDataKhuyenMaiTheoMaSP(string pValue)
        {
            return khuyenmai_dal.getDataKhuyenMaiTheoMaSP(pValue);
        }
    }
}
