using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IMauSacService
    {
        bool Add(MauSacView obj);
        bool Update(MauSacView obj);
        bool Delete(MauSacView obj);
        List<MauSacView> GetAll();
        MauSac GetById(Guid id);
        Guid GetIdFromTen(string ten);
    }
}
