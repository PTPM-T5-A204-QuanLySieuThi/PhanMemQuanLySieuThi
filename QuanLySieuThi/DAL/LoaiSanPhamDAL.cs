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

        //------------------ LẤY DỮ LIỆU LOẠI SẢN PHẨM THEO MÃ LOẠI SẢN PHẨM
        public List<LoaiSanPhamDTO> getDataLoaiSanPhamTheoMaLSP(string pMaLSP)
        {
            var query = from lsp in qlst.LOAISANPHAMs where lsp.MALSP == pMaLSP select lsp;

            var loaisanphams = query.ToList().ConvertAll(lsp => new LoaiSanPhamDTO()
            {
                malsp = lsp.MALSP,
                tenlsp = lsp.TENLSP
            });

            List<LoaiSanPhamDTO> lst_lsp = loaisanphams.ToList();

            return lst_lsp;
        }

        //------------------ LẤY DỮ LIỆU SẢN PHẨM CÓ ĐIỀU KIỆN
        public List<LoaiSanPhamDTO> getDataLoaiSanPhamDK(string pValue)
        {
            var query = from lsp in qlst.LOAISANPHAMs where lsp.TENLSP.Contains(pValue) select lsp;

            var loaisanphams = query.ToList().ConvertAll(lsp => new LoaiSanPhamDTO()
            {
                malsp = lsp.MALSP,
                tenlsp = lsp.TENLSP
            });

            List<LoaiSanPhamDTO> lst_lsp = loaisanphams.ToList();

            return lst_lsp;
        }

        //------------------ THÊM LOẠI SẢN PHẨM
        public void addLSP(LoaiSanPhamDTO lsp)
        {
            LOAISANPHAM lsps = new LOAISANPHAM();

            lsps.MALSP = lsp.malsp;
            lsps.TENLSP = lsp.tenlsp;

            qlst.LOAISANPHAMs.InsertOnSubmit(lsps);
            qlst.SubmitChanges();
        }

        //------------------ XÓA LOẠI SẢN PHẨM
        public bool removeLSP(string pMaLSP)
        {
            LOAISANPHAM lsp = qlst.LOAISANPHAMs.Where(t => t.MALSP == pMaLSP).FirstOrDefault();
            if (lsp != null)
            {
                qlst.LOAISANPHAMs.DeleteOnSubmit(lsp);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA LOẠI SẢN PHẨM
        public void editLSP(LoaiSanPhamDTO lsp)
        {
            LOAISANPHAM lsps = qlst.LOAISANPHAMs.Where(t => t.MALSP == lsp.malsp).FirstOrDefault();

            lsps.MALSP = lsp.malsp;
            lsps.TENLSP = lsp.tenlsp;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from nv in qlst.NHANVIENs where nv.MANV == pCode select nv;
            return query.Any();
        }

    }
}
