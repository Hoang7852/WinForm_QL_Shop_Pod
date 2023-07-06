using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface ITaiKhoanRepos
    {
        bool Add(TaiKhoan taiKhoan);
        bool Update(TaiKhoan taiKhoan);
        bool Delete(TaiKhoan taiKhoan);
        List<TaiKhoan> GetAllTK();
    }
}
