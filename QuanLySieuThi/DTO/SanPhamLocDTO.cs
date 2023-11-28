using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamLocDTO
    {
        public string masp { get; set; }
        public string barcode { get; set; }
        public string tensp { get; set; }
        public DateTime ngaysx { get; set; }
        public DateTime hansd { get; set; }
        public decimal giasp { get; set; }
        public int slton { get; set; }
    }
}
