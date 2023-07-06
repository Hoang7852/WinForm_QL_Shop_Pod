using _2._BUS.ViewModel;
using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface ISizeService
    {
        bool Add(SizeView obj);
        bool Update(SizeView obj);
        bool Delete(SizeView obj);
        Size GetById(Guid id);
        Guid GetIdByName(string input);
        List<SizeView> GetAll();
    }
}
