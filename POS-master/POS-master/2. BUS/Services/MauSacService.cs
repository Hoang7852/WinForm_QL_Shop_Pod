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
    public class MauSacService : IMauSacService
    {
        private IMauSacRepos _imauSacRepos;
        public MauSacService()
        {
            _imauSacRepos = new MauSacRepos();
        }
        public bool Add(MauSacView obj)
        {
            if (obj == null) return false;
            var ms = new MauSac()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_imauSacRepos.Add(ms)) return true;
            return false;
        }

        public bool Delete(MauSacView obj)
        {
            if (obj == null) return false;
            var ms = _imauSacRepos.GetAllMS().FirstOrDefault(c => c.Ten == obj.Ten);
            if (_imauSacRepos.Delete(ms)) return true;
            return false;
        }

        public List<MauSacView> GetAll()
        {
            List<MauSacView> lst = new List<MauSacView>();
            lst =
                (
                    from a in _imauSacRepos.GetAllMS()
                    select new MauSacView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                    }
                ).ToList();
            return lst;
        }

        public MauSac GetById(Guid id)
        {
            return _imauSacRepos.GetAllMS().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdFromTen(string ten)
        {
            return GetAll().FirstOrDefault(c => c.Ten == ten).Id;
        }

        public bool Update(MauSacView obj)
        {
            if (obj == null) return false;
            var size = _imauSacRepos.GetAllMS().FirstOrDefault(c => c.Id == obj.Id);
            size.Ma=obj.Ma;
            size.Ten = obj.Ten;
            if (_imauSacRepos.Update(size)) return true;
            return false;
        }
    }
}
