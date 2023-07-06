using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IHoaDonChiTietService
    {
        bool Add(HoaDonChiTietView obj);
        bool Update(HoaDonChiTietView obj);
        bool Delete(HoaDonChiTietView obj);
        List<HoaDonChiTietView> ShowHoaDonChiTiet(Guid id);
        List<HoaDonChiTietView> ShowHoaDonChiTiet();
        List<HoaDonChiTietView> GetAll();
    }
}
