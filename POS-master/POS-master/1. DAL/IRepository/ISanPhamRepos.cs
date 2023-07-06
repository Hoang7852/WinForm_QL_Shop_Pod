using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface ISanPhamRepos
    {
        bool Add(SanPham sanPham);
        bool Update(SanPham sanPham);
        bool Delete(SanPham sanPham);
        List<SanPham> GetAllSP();
    }
}
