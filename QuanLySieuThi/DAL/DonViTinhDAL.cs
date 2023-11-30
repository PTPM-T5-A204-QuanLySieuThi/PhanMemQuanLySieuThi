using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonViTinhDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public DonViTinhDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU ĐƠN VỊ TÍNH
        public List<DonViTinhDTO> getDataDonViTinh()
        {
            var query = from dvt in qlst.DONVITINHs select dvt;

            var donvitinhs = query.ToList().ConvertAll(dvt => new DonViTinhDTO()
            {
                madvt = dvt.MADVT,
                tendvt = dvt.TENDVT
            });

            List<DonViTinhDTO> lst_dvt = donvitinhs.ToList();

            return lst_dvt;
        }

        //------------------ LẤY TÊN ĐƠN VỊ TÍNH
        public string getTenDonViTinh(string pMaSP)
        {
            var query = from dvt in qlst.DONVITINHs join sp in qlst.SANPHAMs on dvt.MADVT equals sp.MADVT where sp.MASP == pMaSP select dvt.TENDVT;

            return query.FirstOrDefault();
        }
    }
}
