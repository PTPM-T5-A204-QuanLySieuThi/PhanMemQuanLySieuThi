﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public TaiKhoanDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU TÀI KHOẢN
        public List<string> getDataTaiKhoan()
        {
            var query = from tk in qlst.TAIKHOANs select tk.MATK;

            List<string> lst_tk = query.ToList();

            return lst_tk;
        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pRole, string pPass)
        {
            var query = from nv in qlst.NHANVIENs join tk in qlst.TAIKHOANs on nv.MATK equals tk.MATK join tc in qlst.QUYENTRUYCAPs on tk.MAQTC equals tc.MAQTC where tc.TENQTC == pRole && tk.MATKHAU == pPass select nv;
            return query.Any();
        }
    }
}
