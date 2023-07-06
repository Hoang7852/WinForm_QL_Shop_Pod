using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface ILoaiRepos
    {
        bool Add(Loai loai);
        bool Update(Loai loai);
        bool Delete(Loai loai);
        List<Loai> GetAllLoai();
    }
}
