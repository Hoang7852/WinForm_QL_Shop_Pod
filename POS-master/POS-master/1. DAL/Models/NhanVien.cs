using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class NhanVien
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string LinkAnh { get; set; }
        public int TrangThai { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
