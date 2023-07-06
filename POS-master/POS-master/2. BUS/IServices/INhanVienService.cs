using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface INhanVienService
    {
        bool Add(NhanVienView obj);
        bool Update(NhanVienView obj);
        List<NhanVienView> GetAllKH();
        NhanVien GetById(Guid id);
    }
}
