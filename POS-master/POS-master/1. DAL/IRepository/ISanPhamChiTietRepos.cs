using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface ISanPhamChiTietRepos
    {
        bool Add(SanPhamChiTiet sanPhamChiTiet);
        bool Update(SanPhamChiTiet sanPhamChiTiet);
        bool Delete(SanPhamChiTiet sanPhamChiTiet);
        List<SanPhamChiTiet> GetAllSPCT();
    }
}
