using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public string masp {  get; set; }
        public string barcode { get; set; }
        public string tensp { get; set; }
        public string anhsanpham { get; set; }
        public DateTime ngaysx { get; set; }
        public DateTime hansd { get; set; }
        public decimal giasp { get; set; }
        public string mota { get; set; }
        public int slton { get; set; }
        public string manxx { get; set; }
        public string mancc { get; set; }
        public string madvt { get; set; } 
        public string mactlsp { get; set; }
    }
}
