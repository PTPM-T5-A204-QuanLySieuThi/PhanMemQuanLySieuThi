using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanDAL tk_dal = new TaiKhoanDAL();

        public TaiKhoanBLL()
        {

        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pRole, string pPassword)
        {
            return tk_dal.isSuccessLogin(pRole, pPassword);
        }
    }
}
