using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface ISanPhamService
    {
        bool Add(SanPhamView obj);
        bool Update(SanPhamView obj);
        bool Delete(SanPhamView obj);
        List<SanPhamView> GetAll();
        List<SanPhamView> GetAll(string input);
        SanPham GetById(Guid id);
        Guid GetIdByName(string input);
        string GetMaByName(string input);
    }
}
