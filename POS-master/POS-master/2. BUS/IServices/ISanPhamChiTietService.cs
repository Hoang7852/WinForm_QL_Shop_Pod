using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface ISanPhamChiTietService
    {
        bool Add(SanPhamChiTietView obj);

        bool Update(SanPhamChiTietView obj);
        bool Delete(SanPhamChiTietView obj);
        List<SanPhamChiTietView> GetAll();
        string? GETNAME(string? input);
        string? GetMaByID(Guid? id);
        SanPhamChiTiet? GETMASP(string? input);
    }
}
