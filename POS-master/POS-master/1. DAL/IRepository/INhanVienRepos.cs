using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface INhanVienRepos
    {
        bool Add(NhanVien nhanVien);
        bool Update(NhanVien nhanVien);
        bool Delete(NhanVien nhanVien);
        List<NhanVien> GetAllNV();
    }
}
