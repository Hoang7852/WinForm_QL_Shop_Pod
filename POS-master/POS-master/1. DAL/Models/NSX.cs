using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class NSX
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
