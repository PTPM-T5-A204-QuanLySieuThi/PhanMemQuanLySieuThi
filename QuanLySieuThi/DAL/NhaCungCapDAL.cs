using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCapDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public NhaCungCapDAL()
        {

        }


        //------------------ LẤY DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> getDataNhaCungCap()
        {
            var query = from ncc in qlst.NHACUNGCAPs select ncc;

            var nhacungcaps = query.ToList().ConvertAll(ncc => new NhaCungCapDTO()
            {
                mancc = ncc.MANCC,
                tenncc = ncc.TENNCC,
                diachi = ncc.DIACHI,
                sodienthoai = ncc.SODIENTHOAI
            });

            List<NhaCungCapDTO> lst_ncc = nhacungcaps.ToList();

            return lst_ncc;
        }

        //------------------ LẤY DỮ LIỆU NHÀ CUNG CẤP THEO MÃ NHÀ CUNG CẤP
        public List<NhaCungCapDTO> getDataNhaCungCapTheoMaNCC(string pMaNCC)
        {
            var query = from ncc in qlst.NHACUNGCAPs where ncc.MANCC == pMaNCC select ncc;

            var nhacungcaps = query.ToList().ConvertAll(ncc => new NhaCungCapDTO()
            {
                mancc = ncc.MANCC,
                tenncc = ncc.TENNCC,
                diachi = ncc.DIACHI,
                sodienthoai = ncc.SODIENTHOAI
            });

            List<NhaCungCapDTO> lst_ncc = nhacungcaps.ToList();

            return lst_ncc;
        }

        //------------------ TÌM DỮ LIỆU NHÀ CUNG CẤP
        public List<NhaCungCapDTO> findDataNhaCungCap(string pValue)
        {
            var query = from ncc in qlst.NHACUNGCAPs where ncc.MANCC.Contains(pValue) || ncc.TENNCC.Contains(pValue) select ncc;

            var nhacungcaps = query.ToList().ConvertAll(ncc => new NhaCungCapDTO()
            {
                mancc = ncc.MANCC,
                tenncc = ncc.TENNCC,
                diachi = ncc.DIACHI,
                sodienthoai = ncc.SODIENTHOAI
            });

            List<NhaCungCapDTO> lst_ncc = nhacungcaps.ToList();

            return lst_ncc;
        }

        //------------------ THÊM NHÀ CUNG CẤP
        public void addNCC(NhaCungCapDTO ncc)
        {
            NHACUNGCAP nccs = new NHACUNGCAP();

            nccs.MANCC = ncc.mancc;
            nccs.TENNCC = ncc.tenncc;
            nccs.DIACHI = ncc.diachi;
            nccs.SODIENTHOAI = ncc.sodienthoai;

            qlst.NHACUNGCAPs.InsertOnSubmit(nccs);
            qlst.SubmitChanges();
        }

        //------------------ XÓA NHÀ CUNG CẤP
        public bool removeNCC(string pMaNCC)
        {
            NHACUNGCAP ncc = qlst.NHACUNGCAPs.Where(t => t.MANCC == pMaNCC).FirstOrDefault();
            if (ncc != null)
            {
                qlst.NHACUNGCAPs.DeleteOnSubmit(ncc);
                qlst.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA NHÀ CUNG CẤP
        public void editNCC(NhaCungCapDTO ncc)
        {
            NHACUNGCAP nccs = qlst.NHACUNGCAPs.Where(t => t.MANCC == ncc.mancc).FirstOrDefault();

            nccs.MANCC = ncc.mancc;
            nccs.TENNCC = ncc.tenncc;
            nccs.DIACHI = ncc.diachi;
            nccs.SODIENTHOAI = ncc.sodienthoai;

            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from ncc in qlst.NHACUNGCAPs where ncc.MANCC == pCode select ncc;
            return query.Any();
        }

        //------------------ LẤY TÊN NHÀ CUNG CẤP
        public string getTenNhaCungCap(string pMaSP)
        {
            var query = from ncc in qlst.NHACUNGCAPs join sp in qlst.SANPHAMs on ncc.MANCC equals sp.MANCC where sp.MASP == pMaSP select ncc.TENNCC;

            return query.FirstOrDefault();
        }
    }
}
