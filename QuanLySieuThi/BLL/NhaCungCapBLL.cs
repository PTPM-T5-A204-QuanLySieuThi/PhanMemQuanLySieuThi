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

        //------------------ LẤY DỮ LIỆU NHÀ CUNG CẤP THEO MÃ NHÀ CUNG CẤP
        public List<NhaCungCapDTO> getDataNhaCungCapTheoMaNCC(string pMaNCC)
        {
            return nhacungcap_dal.getDataNhaCungCapTheoMaNCC(pMaNCC);
        }

        //------------------ TÌM DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> findDataNhaCungCap(string pValue)
        {
            return nhacungcap_dal.findDataNhaCungCap(pValue);
        }

        //------------------ THÊM NHÀ CUNG CẤP
        public void addNCC(NhaCungCapDTO ncc)
        {
            nhacungcap_dal.addNCC(ncc);
        }

        //------------------ XÓA NHÀ CUNG CẤP
        public bool removeNCC(string pMaNCC)
        {
            return nhacungcap_dal.removeNCC(pMaNCC);
        }

        //------------------ SỬA NHÀ CUNG CẤP
        public void editNCC(NhaCungCapDTO ncc)
        {
            nhacungcap_dal.editNCC(ncc);
        }

        //------------------ LẤY TÊN NHÀ CUNG CẤP
        public string getTenNhaCungCap(string pMaSP)
        {
            return nhacungcap_dal.getTenNhaCungCap(pMaSP);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            return nhacungcap_dal.checkPK(pCode);
        }
    }
}
