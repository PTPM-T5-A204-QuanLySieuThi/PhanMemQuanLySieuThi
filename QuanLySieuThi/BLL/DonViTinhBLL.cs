using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DonViTinhBLL
    {
        DonViTinhDAL donvitinh_dal = new DonViTinhDAL();

        public DonViTinhBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU ĐƠN VỊ TÍNH
        public List<DonViTinhDTO> getDataDonViTinh()
        {
            return donvitinh_dal.getDataDonViTinh();
        }

        //------------------ LẤY TÊN ĐƠN VỊ TÍNH
        public string getTenDonViTinh(string pMaSP)
        {
            return donvitinh_dal.getTenDonViTinh(pMaSP);
        }
    }
}
