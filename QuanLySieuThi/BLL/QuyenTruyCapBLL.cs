using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class QuyenTruyCapBLL
    {
        QuyenTruyCapDAL qtc_dal = new QuyenTruyCapDAL();

        public QuyenTruyCapBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU QUYỀN TRUY CẬP
        public List<QUYENTRUYCAP> getListQuyenTruyCap()
        {
            return qtc_dal.getDataQuyenTruyCap();
        }

        //------------------ LẤY DỮ LIỆU TÊN QUYỀN TRUY CẬP
        public List<string> getListTenQuyenTruyCap()
        {
            return qtc_dal.getDataTenQuyenTruyCap();
        }
    }
}
