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
    public class SanPhamService : ISanPhamService
    {
        private ISanPhamRepos _iSanPhamRepos;
        List<SanPhamView> _lstSanPham;
        public SanPhamService()
        {
            _iSanPhamRepos = new SanPhamRepos();
            _lstSanPham = new List<SanPhamView>();

        }
        public bool Add(SanPhamView obj)
        {
            if (obj == null) return false;
            var sanPham = new SanPham()
            {
                Id = Guid.NewGuid(),
                Ma=obj.Ma,
                Ten = obj.Ten,
                TrangThai=obj.TrangThai,
            };
            if (_iSanPhamRepos.Add(sanPham)) return true;
            return false;
        }

        public bool Delete(SanPhamView obj)
        {
            if (obj == null) return false;
            var sanPham = _iSanPhamRepos.GetAllSP().FirstOrDefault(c => c.Id == obj.Id);
            sanPham.Ten = obj.Ten;
            if (_iSanPhamRepos.Update(sanPham)) return true;
            return false;
        }

        public List<SanPhamView> GetAll()
        {
            List<SanPhamView> lst = new List<SanPhamView>();
            lst =
                (
                    from a in _iSanPhamRepos.GetAllSP()
                    select new SanPhamView()
                    {
                        Id = a.Id,
                        Ma=a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai
                    }
                ).ToList();
            return lst;
        }

        public List<SanPhamView> GetAll(string input)
        {
            throw new NotImplementedException();
        }

        public SanPham GetById(Guid id)
        {
            return _iSanPhamRepos.GetAllSP().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public string GetMaByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Ma;
        }

        public bool Update(SanPhamView obj)
        {
            if (obj == null) return false;
            var sanPham = _iSanPhamRepos.GetAllSP().FirstOrDefault(c => c.Id == obj.Id);
            sanPham.Ma=obj.Ma;
            sanPham.Ten = obj.Ten;
            sanPham.TrangThai = obj.TrangThai;
            if (_iSanPhamRepos.Update(sanPham)) return true;
            return false;
        }
    }
}
