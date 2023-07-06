using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class HoaDonChiTietView
    {
        public HoaDon HoaDon { get; set; }
        public SanPhamChiTiet SanPhamChiTiet { get; set; }
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
        public double GiaDaGiam { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public Guid ID_HD { get; set; }
        public Guid ID_SPCT { get; set; }
        public Guid ID_HDS { get; set; }
        public string TenSP { get; set; }
        public int TrangThai { get; set; }
        public double TongTien { get; set; }
        public double GiamGia { get; set; }
    }
}
