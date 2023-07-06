using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IKhachHangRepos
    {
        bool Add(KhachHang khachHang);
        bool Update(KhachHang khachHang);
        bool Delete(KhachHang khachHang);
        List<KhachHang> GetAllKH();
    }
}
