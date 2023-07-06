using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IBaoCaoRepos
    {
        bool Add(BaoCao baoCao);
        bool Update(BaoCao baoCao);
        bool Delete(BaoCao baoCao);
        List<BaoCao> GetAllBC();
    }
}
