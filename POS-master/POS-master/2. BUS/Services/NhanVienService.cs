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
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepos _iNhanVienRepos;
        private List<NhanVien> _lstNhanViens;
        public NhanVienService()
        {
            _iNhanVienRepos = new NhanVienRepos();
            _lstNhanViens = new List<NhanVien>();

        }
        public bool Add(NhanVienView obj)
        {
            if (obj == null) return false;
            var nv = new NhanVien()
            {
                ID = obj.ID,
                Ma=obj.Ma,
                Ten = obj.Ten,
                DiaChi = obj.DiaChi,
                SDT=obj.SDT,
                LinkAnh = obj.LinkAnh,
                TrangThai = obj.TrangThai,

            };
            if (_iNhanVienRepos.Add(nv)) return true;
            return false;
        }

        public List<NhanVienView> GetAllKH()
        {
            List<NhanVienView> lst = new List<NhanVienView>();
            lst =
                (
                    from a in _iNhanVienRepos.GetAllNV()
                    select new NhanVienView()
                    {
                        ID = a.ID,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        SDT = a.SDT,
                        DiaChi = a.DiaChi,
                        LinkAnh=a.LinkAnh,
                        TrangThai=a.TrangThai,
                    }
                ).ToList();
            return lst;
        }

        public NhanVien GetById(Guid id)
        {
            return _iNhanVienRepos.GetAllNV().FirstOrDefault(c => c.ID == id);
        }

        public bool Update(NhanVienView obj)
        {
            if (obj == null) return false;
            var nv = _iNhanVienRepos.GetAllNV().FirstOrDefault(c => c.ID == obj.ID);
            nv.Ma=obj.Ma;
            nv.Ten = obj.Ten;
            nv.SDT = obj.SDT;
            nv.DiaChi = obj.DiaChi;
            nv.LinkAnh = obj.LinkAnh;
            nv.TrangThai = obj.TrangThai;
            if (_iNhanVienRepos.Update(nv)) return true;
            return false;
        }
    }
}
