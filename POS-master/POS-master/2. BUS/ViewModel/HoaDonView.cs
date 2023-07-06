using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class HoaDonView
    {
        public HoaDon HoaDon { get; set; }
        public NhanVien NhanVien { get; set; }
        public KhachHang KhachHang { get; set; }
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenNv { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public DateTime NgayMua { get; set; }
        public int TrangThai { get; set; }
        public Guid ID_NV { get; set; }
        public Guid ID_KH { get; set; }
        public string TTNv { get; set; }
        public string TenKh { get; set; }
        public string Sdt { get; set; }
        public double DiemTichLuy { get; set; }
    }
}
