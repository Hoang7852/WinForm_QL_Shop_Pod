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
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private IHoaDonChiTietRepos _IHoaDonChiTietRepos;
        private IHoaDonRepos _IHoaDonRepos;
        private ISanPhamRepos _sanPhamRepos;
        private ISanPhamChiTietRepos _iSanPhamChiTietRepos;
        public HoaDonChiTietService()
        {
            _IHoaDonChiTietRepos = new HoaDonChiTietRepos();
            _IHoaDonRepos = new HoaDonRepos();
            _sanPhamRepos = new SanPhamRepos();
            _iSanPhamChiTietRepos = new SanPhamChiTietRepos();
        }
        public bool Add(HoaDonChiTietView obj)
        {
            if (obj == null) return false;
            var hoaDonChiTiet = new HoaDonChiTiet()
            {
                Id = Guid.NewGuid(),
                ID_HD = obj.Id,
                ID_SPCT = obj.ID_SPCT,
                Ma=obj.Ma,
                GiaDaGiam=obj.GiaDaGiam,
                SoLuong = obj.SoLuong,
            };
            if (_IHoaDonChiTietRepos.Add(hoaDonChiTiet)) return true;
            return false;
        }

        public bool Delete(HoaDonChiTietView obj)
        {
            if (obj == null) return false;
            var hoaDonChiTiet = _IHoaDonChiTietRepos.GetAllHDCT().FirstOrDefault(c => c.ID_HD == obj.ID_HD && c.ID_SPCT == obj.ID_SPCT);
            if (_IHoaDonChiTietRepos.Delete(hoaDonChiTiet)) return true;
            return false;
        }

        public List<HoaDonChiTietView> GetAll()
        {
            var data =
               (
                   from a in _IHoaDonChiTietRepos.GetAllHDCT()
                   join b in _IHoaDonRepos.GetAllHD() on a.ID_HD equals b.Id                  
                   join c in _iSanPhamChiTietRepos.GetAllSPCT() on a.ID_SPCT equals c.Id
                   join d in _sanPhamRepos.GetAllSP() on c.ID_SP equals d.Id
                   select new HoaDonChiTietView()
                   {
                       Id = a.Id,
                       ID_HD=b.Id,
                       ID_SPCT=c.Id,
                       Ma=a.Ma,
                       TenSP = d.Ten,
                       SoLuong = a.SoLuong,
                       Gia=c.GiaNiemYet,
                       GiaDaGiam=a.GiaDaGiam,
                       NgayThanhToan = b.NgayThanhToan
                   }
               ).ToList();
            return data;
        }

        public List<HoaDonChiTietView> ShowHoaDonChiTiet(Guid id)
        {
            var data =
                (
                    from a in _IHoaDonChiTietRepos.GetAllHDCT()
                    join b in _IHoaDonRepos.GetAllHD() on a.ID_HD equals b.Id
                    join c in _iSanPhamChiTietRepos.GetAllSPCT() on a.ID_SPCT equals c.Id
                    join d in _sanPhamRepos.GetAllSP() on c.ID_SP equals d.Id
                    where a.ID_HD == id || a.ID_SPCT == id

                    select new HoaDonChiTietView()
                    {
                        Id = a.Id,
                        ID_SPCT = c.Id,
                        TenSP = d.Ten,
                        SoLuong = a.SoLuong,
                        Gia=c.GiaNiemYet,
                        GiaDaGiam=a.GiaDaGiam,
                        TrangThai=b.TrangThai,
                    }
                ).ToList();
            return data;
        }

        public List<HoaDonChiTietView> ShowHoaDonChiTiet()
        {
            var data =
                (
                    from a in _IHoaDonChiTietRepos.GetAllHDCT()
                    join b in _IHoaDonRepos.GetAllHD() on a.ID_HD equals b.Id
                    join c in _iSanPhamChiTietRepos.GetAllSPCT() on a.ID_SPCT equals c.Id
                    join d in _sanPhamRepos.GetAllSP() on c.ID_SP equals d.Id

                    select new HoaDonChiTietView()
                    {
                        Id = a.Id,
                        ID_SPCT = c.Id,
                        Ma=c.Ma,
                        TenSP = d.Ten,
                        SoLuong = a.SoLuong,
                        Gia=c.GiaNiemYet,
                        GiaDaGiam=a.GiaDaGiam,
                        TrangThai=b.TrangThai,
                    }
                ).ToList();
            return data;
        }

        public bool Update(HoaDonChiTietView obj)
        {
            if (obj == null) return false;
            var hoaDonChiTiet = _IHoaDonChiTietRepos.GetAllHDCT().FirstOrDefault(c => c.ID_HD == obj.ID_HD && c.ID_SPCT == obj.ID_SPCT || c.Id == obj.Id);
            hoaDonChiTiet.Ma = obj.Ma;
            hoaDonChiTiet.SoLuong = obj.SoLuong;
            if (_IHoaDonChiTietRepos.Update(hoaDonChiTiet)) return true;
            return false;
        }
    }
}
