using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public LoaiSanPhamDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU LOẠI SẢN PHẨM
        public List<LoaiSanPhamDTO> getDataLoaiSanPham()
        {
            var query = from lsp in qlst.LOAISANPHAMs select lsp;

            var loaisanphams = query.ToList().ConvertAll(lsp => new LoaiSanPhamDTO()
            {
                malsp = lsp.MALSP,
                tenlsp = lsp.TENLSP
            });

            List<LoaiSanPhamDTO> lst_lsp = loaisanphams.ToList();

            return lst_lsp;
        }
    }
}
