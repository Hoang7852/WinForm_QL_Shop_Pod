using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IKhachHangService
    {
        bool Add(KhanhHangView obj);
        bool Update(KhanhHangView obj);
        List<KhanhHangView> GetAllKH();
        KhachHang GetById(Guid id);
    }
}
