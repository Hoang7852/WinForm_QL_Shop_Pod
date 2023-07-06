using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayMua { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int TrangThai { get; set; }
        public Guid ID_NV { get; set; }
        public Guid ID_KH { get; set; }
        public virtual NhanVien NhanViens { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
