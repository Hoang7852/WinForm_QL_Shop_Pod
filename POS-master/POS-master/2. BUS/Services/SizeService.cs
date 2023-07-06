using _1._DAL.IRepository;
using _1._DAL.Repository;
using _2._BUS.IServices;
using _2._BUS.ViewModel;
using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.Services
{
    public class SizeService : ISizeService
    {
        private ISizeRepos _isizeRepos;
        public SizeService()
        {
            _isizeRepos = new SizeRepos();
        }
        public bool Add(SizeView obj)
        {
            if (obj == null) return false;
            var size = new Size()
            {
                Ma=obj.Ma,
                Ten = obj.Ten,
            };
            if (_isizeRepos.Add(size)) return true;
            return false;
        }

        public bool Delete(SizeView obj)
        {
            if (obj == null) return false;
            var size = _isizeRepos.GetAllSize().FirstOrDefault(c => c.Ten == obj.Ten);
            if (_isizeRepos.Delete(size)) return true;
            return false;
        }

        public List<SizeView> GetAll()
        {
            List<SizeView> lst = new List<SizeView>();
            lst =
                (
                    from a in _isizeRepos.GetAllSize()
                    select new SizeView()
                    {
                        Id = a.Id,
                        Ma=a.Ma,
                        Ten = a.Ten,
                    }
                ).ToList();
            return lst;
        }

        public Size GetById(Guid id)
        {
            return _isizeRepos.GetAllSize().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return (Guid)GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public bool Update(SizeView obj)
        {
            if (obj == null) return false;
            var size = _isizeRepos.GetAllSize().FirstOrDefault(c => c.Id == obj.Id);
            size.Ma=obj.Ma;
            size.Ten=obj.Ten;
            if (_isizeRepos.Update(size)) return true;
            return false;
        }
    }
}
