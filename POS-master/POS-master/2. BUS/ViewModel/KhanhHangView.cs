using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class KhanhHangView
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public double DiemTichLuy { get; set; }
        public double TongTien { get; set; }
    }
}
