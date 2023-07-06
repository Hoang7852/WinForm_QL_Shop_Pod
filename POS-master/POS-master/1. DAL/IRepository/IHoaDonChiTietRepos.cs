using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IHoaDonChiTietRepos
    {
        bool Add(HoaDonChiTiet hoaDonChiTiet);
        bool Update(HoaDonChiTiet hoaDonChiTiet);
        bool Delete(HoaDonChiTiet hoaDonChiTiet);
        List<HoaDonChiTiet> GetAllHDCT();
    }
}
