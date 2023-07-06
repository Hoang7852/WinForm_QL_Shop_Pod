using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface INsxService
    {
        bool Add(NsxView obj);
        bool Update(NsxView obj);
        bool Delete(NsxView obj);
        NSX GetById(Guid id);
        Guid GetIdByName(string input);
        List<NsxView> GetAll();
    }
}
