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

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI THEO MÃ KHUYẾN MÃI
        public List<KhuyenMaiDTO> getDataKhuyenMaiTheoMaKM(string pMaKM)
        {
            return khuyenmai_dal.getDataKhuyenMaiTheoMaKM(pMaKM);
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI THEO MÃ SẢN PHẨM
        public KhuyenMaiDTO getDataKhuyenMaiTheoMaSP(string pValue)
        {
            return khuyenmai_dal.getDataKhuyenMaiTheoMaSP(pValue);
        }

        //------------------ LẤY DỮ LIỆU KHUYẾN MÃI CÓ ĐIỀU KIỆN
        public List<KhuyenMaiDTO> getDataKhuyenMaiDK(string pValue)
        {
            return khuyenmai_dal.getDataKhuyenMaiDK(pValue);
        }

        //------------------ THÊM KHUYẾN MÃI
        public void addKM(KhuyenMaiDTO km)
        {
            khuyenmai_dal.addKM(km);
        }

        //------------------ XÓA KHUYẾN MÃI
        public bool removeKM(string pMaKM)
        {
            return khuyenmai_dal.removeKM(pMaKM);
        }

        //------------------ SỬA KHUYẾN MÃI
        public void editKM(KhuyenMaiDTO km)
        {
            khuyenmai_dal.editKM(km);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return khuyenmai_dal.checkPK(pCode);
        }
    }
}
