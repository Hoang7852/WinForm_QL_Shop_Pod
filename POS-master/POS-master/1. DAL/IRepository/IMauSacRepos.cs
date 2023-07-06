using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IMauSacRepos
    {
        bool Add(MauSac mauSac);
        bool Update(MauSac mauSac);
        bool Delete(MauSac mauSac);
        List<MauSac> GetAllMS();
    }
}
