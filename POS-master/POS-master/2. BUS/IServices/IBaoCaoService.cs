using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IBaoCaoService
    {
        bool Add(BaoCaoView obj);
        bool Update(BaoCaoView obj);
        List<BaoCaoView> GetAllKH();
        BaoCao GetById(Guid id);
    }
}
