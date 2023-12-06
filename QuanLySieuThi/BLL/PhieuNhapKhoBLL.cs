using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapKhoBLL
    {

        PhieuNhapKhoDAL phieunhapkho_dal = new PhieuNhapKhoDAL();

        public PhieuNhapKhoBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU PHIẾU NHẬP KHO
        public List<PhieuNhapKhoDTO> getDataPhieuNhapKho()
        {
            return phieunhapkho_dal.getDataPhieuNhapKho();
        }

        //------------------ LẤY DỮ LIỆU PHIẾU NHẬP KHO CÓ ĐIỀU KIỆN
        public List<PhieuNhapKhoDTO> getDataPhieuNhapKhoDK(string pMaPhieu)
        {
            return phieunhapkho_dal.getDataPhieuNhapKhoDK(pMaPhieu);
        }

        //------------------ THÊM PHIẾU NHẬP KHO
        public void addPNK(PhieuNhapKhoDTO pnk)
        {
            phieunhapkho_dal.addPNK(pnk);
        }

        //------------------ XÓA PHIẾU NHẬP KHO
        public bool removePNK(string pMaPhieu)
        {
            return phieunhapkho_dal.removePNK(pMaPhieu);
        }

        //------------------ SỬA PHIẾU NHẬP KHO
        public void editPNK(PhieuNhapKhoDTO pnk)
        {
            phieunhapkho_dal.editPNK(pnk);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
           return phieunhapkho_dal.checkPK(pCode);
        }
    }
}
