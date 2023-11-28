﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class HoaDonDAL
    {
        QLSTDataContext qlst = new QLSTDataContext();

        public HoaDonDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDon()
        {
            var query = from hd in qlst.HOADONs select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                tongtien = nv.TONGTIEN,
                ngaylap = nv.NGAYLAP,
                thanhtien = nv.THANHTIEN,
                manv = nv.MANV
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ LẤY DỮ LIỆU HÓA ĐƠN THEO MÃ HÓA ĐƠN
        public List<HoaDonDTO> getDataHoaDonTheoMaHD(string pMaHD)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD == pMaHD select hd;

            var hoadons = query.ToList().ConvertAll(nv => new HoaDonDTO()
            {
                mahd = nv.MAHD,
                tongtien = nv.TONGTIEN,
                ngaylap = nv.NGAYLAP,
                thanhtien = nv.THANHTIEN,
                manv = nv.MANV,
            });

            List<HoaDonDTO> lst_hd = hoadons.ToList();

            return lst_hd;
        }

        //------------------ THÊM HÓA ĐƠN
        public void addHD(HoaDonDTO hd)
        {
            HOADON hds = new HOADON();

            hds.MAHD = hd.mahd;
            hds.NGAYLAP = hd.ngaylap;
            hds.TONGTIEN = hd.tongtien;
            hds.THANHTIEN = hd.thanhtien;
            hds.MANV = hd.manv;

            qlst.HOADONs.InsertOnSubmit(hds);
            qlst.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pCode)
        {
            var query = from hd in qlst.HOADONs where hd.MAHD == pCode select hd;
            return query.Any();
        }

    }
}