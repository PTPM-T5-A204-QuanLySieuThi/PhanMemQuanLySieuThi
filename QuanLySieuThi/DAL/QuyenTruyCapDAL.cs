using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuyenTruyCapDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public QuyenTruyCapDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU QUYỀN TRUY CẬP
        public List<QUYENTRUYCAP> getDataQuyenTruyCap()
        {
            var query = from tc in qlst.QUYENTRUYCAPs select tc;

            var quyentruycaps = query.ToList().ConvertAll(qtc => new QUYENTRUYCAP()
            {
                MAQTC = qtc.MAQTC,
                TENQTC = qtc.TENQTC
            });

            List<QUYENTRUYCAP> lst_qtc = quyentruycaps.ToList<QUYENTRUYCAP>();

            return lst_qtc;
        }

        //------------------ LẤY DỮ LIỆU TÊN QUYỀN TRUY CẬP
        public List<string> getDataTenQuyenTruyCap()
        {
            var quyentruycaps = from tc in qlst.QUYENTRUYCAPs select tc.TENQTC;

            List<string> lst_tqtc = quyentruycaps.ToList();

            return lst_tqtc;
        }
    }
}
