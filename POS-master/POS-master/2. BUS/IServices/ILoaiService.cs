using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface ILoaiService
    {
        bool Add(LoaiView obj);
        bool Update(LoaiView obj);
        bool Delete(LoaiView obj);
        Loai GetById(Guid id);
        Guid GetIdByName(string input);
        List<LoaiView> GetAll();
    }
}
