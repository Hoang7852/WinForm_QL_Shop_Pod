using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public int SoLuong { get; set; }
        public double GiaDaGiam { get; set; }
        public Guid ID_HD { get; set; }
        public Guid ID_SPCT { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
    }
}
