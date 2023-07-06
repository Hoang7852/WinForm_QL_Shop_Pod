using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class SanPhamView
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public double Gia { get; set; }
        public int TrangThai { get; set; }
    }
}
