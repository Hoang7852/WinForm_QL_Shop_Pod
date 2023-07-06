using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IHoaDonService
    {
        bool Add(HoaDonView obj);
        bool Update(HoaDonView obj);
        bool Delete(HoaDonView obj);
        List<string> TrangThai();
        List<HoaDon>? GetAllView();

        List<HoaDonView>? GetAll();
    }
}
