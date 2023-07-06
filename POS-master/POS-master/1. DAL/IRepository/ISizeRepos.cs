using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface ISizeRepos
    {
        bool Add(Size size);
        bool Update(Size size);
        bool Delete(Size size);
        List<Size> GetAllSize();
    }
}
