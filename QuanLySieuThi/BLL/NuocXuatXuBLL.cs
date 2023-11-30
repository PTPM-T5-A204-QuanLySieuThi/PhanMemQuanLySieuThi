using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NuocXuatXuBLL
    {
        NuocXuatXuDAL nuocxuatxu_dal = new NuocXuatXuDAL();

        public NuocXuatXuBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU NƯỚC XUẤT XỨ
        public List<NuocXuatXuDTO> getDataNuocXuatXu()
        {
            return nuocxuatxu_dal.getDataNuocXuatXu();
        }

        //------------------ LẤY TÊN NƯỚC XUẤT XỨ
        public string getTenNuocXuatXu(string pMaSP)
        {
            return nuocxuatxu_dal.getTenNuocXuatXu(pMaSP);
        }
    }
}
