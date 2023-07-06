using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IHoaDonRepos
    {
        bool Add(HoaDon hoaDon);
        bool Update(HoaDon hoaDon);
        bool Delete(HoaDon hoaDon);
        List<HoaDon> GetAllHD();
    }
}
