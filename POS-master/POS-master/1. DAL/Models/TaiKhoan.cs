using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class TaiKhoan
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Guid Id_NV { get; set; }
        public int ChucVu { get; set; }
        public int TrangThai { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
