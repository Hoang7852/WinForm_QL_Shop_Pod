using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class TaiKhoanView
    {
        public TaiKhoan TaiKhoan { get; set; }
        public NhanVien NhanVien { get; set; }
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Guid Id_NV { get; set; }
        public int ChucVu { get; set; }
        public int TrangThai { get; set; }
    }
}
