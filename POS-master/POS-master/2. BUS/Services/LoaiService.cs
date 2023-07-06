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
    public class LoaiService : ILoaiService
    {
        private ILoaiRepos _iloaiRepos;
        public LoaiService()
        {
            _iloaiRepos = new LoaiRepos();
        }
        public bool Add(LoaiView obj)
        {
            if (obj == null) return false;
            var size = new Loai()
            {
                Ma=obj.Ma,
                Ten = obj.Ten,
            };
            if (_iloaiRepos.Add(size)) return true;
            return false;
        }

        public bool Delete(LoaiView obj)
        {
            if (obj == null) return false;
            var size = _iloaiRepos.GetAllLoai().FirstOrDefault(c => c.Ten == obj.Ten);
            if (_iloaiRepos.Delete(size)) return true;
            return false;
        }

        public List<LoaiView> GetAll()
        {
            List<LoaiView> lst = new List<LoaiView>();
            lst =
                (
                    from a in _iloaiRepos.GetAllLoai()
                    select new LoaiView()
                    {
                        Id = a.Id,
                        Ma=a.Ma,
                        Ten = a.Ten,
                    }
                ).ToList();
            return lst;
        }

        public Loai GetById(Guid id)
        {
            return _iloaiRepos.GetAllLoai().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public bool Update(LoaiView obj)
        {
            if (obj == null) return false;
            var size = _iloaiRepos.GetAllLoai().FirstOrDefault(c => c.Id == obj.Id);
            size.Ten = obj.Ten;
            if (_iloaiRepos.Update(size)) return true;
            return false;
        }
    }
}
