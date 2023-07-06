using _1._DAL.IRepository;
using _1._DAL.Repository;
using _1._DAL.Models;
using _2._BUS.IServices;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.Services
{
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepos _iKhachHangRepos;
        private List<KhachHang> _lstKhachHangs;
        public KhachHangService()
        {
            _iKhachHangRepos = new KhachHangRepos();
            _lstKhachHangs = new List<KhachHang>();
        }
        public bool Add(KhanhHangView obj)
        {
            if (obj == null) return false;
            var kh = new KhachHang()
            {
                Id = obj.Id,
                Ma=obj.Ma,
                TenKH = obj.TenKH,
                SDT = obj.SDT,
                DiemTichLuy = obj.DiemTichLuy,

            };
            if (_iKhachHangRepos.Add(kh)) return true;
            return false;
        }
        public KhachHang GetById(Guid id)
        {
            return _iKhachHangRepos.GetAllKH().FirstOrDefault(c => c.Id == id);
        }

        public bool Update(KhanhHangView obj)
        {
            if (obj == null) return false;
            var kh = _iKhachHangRepos.GetAllKH().FirstOrDefault(c => c.Id == obj.Id);
            kh.Ma=obj.Ma;
            kh.TenKH = obj.TenKH;
            kh.SDT = obj.SDT;
            kh.DiemTichLuy = obj.DiemTichLuy;
            if (_iKhachHangRepos.Update(kh)) return true;
            return false;
        }

        List<KhanhHangView> IKhachHangService.GetAllKH()
        {
            List<KhanhHangView> lst = new List<KhanhHangView>();
            lst =
                (
                    from a in _iKhachHangRepos.GetAllKH()
                    select new KhanhHangView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        TenKH = a.TenKH,
                        SDT = a.SDT,
                        DiemTichLuy = a.DiemTichLuy,
                    }
                ).ToList();
            return lst;
        }
    }
}
