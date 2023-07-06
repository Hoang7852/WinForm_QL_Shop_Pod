using _1._DAL.IRepository;
using _1._DAL.Models;
using _1._DAL.Repository;
using _2._BUS.IServices;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.Services
{
    public class NsxService : INsxService
    {
        private INSXRepos _inSXRepos;
        public NsxService()
        {
            _inSXRepos = new NSXRepos();
        }
        public bool Add(NsxView obj)
        {
            if (obj == null) return false;
            var nsx = new NSX()
            {
                Ma=obj.Ma,
                Ten = obj.Ten,
                SDT=obj.SDT,
                DiaChi=obj.DiaChi,
            };
            if (_inSXRepos.Add(nsx)) return true;
            return false;
        }

        public bool Delete(NsxView obj)
        {
            if (obj == null) return false;
            var ms = _inSXRepos.GetAllNSX().FirstOrDefault(c => c.Ten == obj.Ten);
            if (_inSXRepos.Delete(ms)) return true;
            return false;
        }

        public List<NsxView> GetAll()
        {
            List<NsxView> lst = new List<NsxView>();
            lst =
                (
                    from a in _inSXRepos.GetAllNSX()
                    select new NsxView()
                    {
                        Id = a.Id,
                        Ma=a.Ma,
                        Ten = a.Ten,
                        SDT = a.SDT,
                        DiaChi=a.DiaChi,
                    }
                ).ToList();
            return lst;
        }

        public NSX GetById(Guid id)
        {
            return _inSXRepos.GetAllNSX().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public bool Update(NsxView obj)
        {
            if (obj == null) return false;
            var nsx = _inSXRepos.GetAllNSX().FirstOrDefault(c => c.Id == obj.Id);
            nsx.Ma=obj.Ma;
            nsx.Ten = obj.Ten;
            nsx.SDT = obj.SDT;
            nsx.DiaChi = obj.DiaChi;
            if (_inSXRepos.Update(nsx)) return true;
            return false;
        }
    }
}
