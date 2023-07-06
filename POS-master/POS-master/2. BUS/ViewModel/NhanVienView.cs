using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class NhanVienView
    {
        //public NhanVien NhanVien { get; set; }
        //public TaiKhoan TaiKhoan { get; set; }
        public Guid ID { get; set; }
        //public Guid IdTK { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string LinkAnh { get; set; }
        public int TrangThai { get; set; }
        public Guid IdTk { get; set; }
        public string MaTk { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Guid Id_NV { get; set; }
        public int ChucVu { get; set; }
        public int TrangThaiTk { get; set; }
    }
}
