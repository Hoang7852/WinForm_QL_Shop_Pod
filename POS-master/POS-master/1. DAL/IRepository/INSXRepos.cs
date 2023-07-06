using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface INSXRepos
    {
        bool Add(NSX nSX);
        bool Update(NSX nSX);
        bool Delete(NSX nSX);
        List<NSX> GetAllNSX();
    }
}
