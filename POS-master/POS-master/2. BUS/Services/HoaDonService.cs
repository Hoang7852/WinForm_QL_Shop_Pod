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

    public class HoaDonService : IHoaDonService
    {
        private IHoaDonRepos _ihoaDonRepos;
        private INhanVienRepos _inhanVienRepos;
        private IKhachHangRepos _ikhachHangRepos;
        private INhanVienService _inhanVienService;
        private List<HoaDon> _lsthoaDons;
        DateTime? nullDateTime = null;
        public HoaDonService()
        {
            _ihoaDonRepos = new HoaDonRepos();
            _inhanVienRepos = new NhanVienRepos();
            _ikhachHangRepos=new KhachHangRepos();
            _inhanVienService = new NhanVienService();
            _lsthoaDons = new List<HoaDon>();
        }
        public bool Add(HoaDonView obj)
        {
            if (obj == null) return false;
            var hd = new HoaDon()
            {
                Id = Guid.NewGuid(),
                Ma=obj.Ma,
                NgayMua = obj.NgayMua,
                NgayThanhToan=obj.NgayThanhToan,
                TrangThai = obj.TrangThai,
                ID_NV = obj.ID_NV,
                ID_KH = obj.ID_KH,

            };
            if (_ihoaDonRepos.Add(hd)) return true;
            return false;
        }
    

        public bool Delete(HoaDonView obj)
        {
            if (obj == null) return false;
            var hoaDon = _ihoaDonRepos.GetAllHD().FirstOrDefault(c => c.Id == obj.Id);
            if (_ihoaDonRepos.Delete(hoaDon)) return true;
            return false;
        }

        

        public List<HoaDonView>? GetAll()
        {
            var data =
                (
                    from a in _ihoaDonRepos.GetAllHD()
                    join b in _ikhachHangRepos.GetAllKH() on a.ID_KH equals b.Id
                    join c in _inhanVienService.GetAllKH() on a.ID_NV equals c.ID 
                    select new HoaDonView()
                    {
                        Id = a.Id,
                        Ma=a.Ma,
                        NgayMua = a.NgayMua == null ? nullDateTime.Value : a.NgayMua,
                        NgayThanhToan = a.NgayThanhToan == null ? nullDateTime.Value : a.NgayThanhToan,
                        ID_NV = c.ID,
                        ID_KH = b.Id == Guid.Empty ? Guid.Empty : b.Id,
                        TrangThai = a.TrangThai,
                        TenKh = b.TenKH,
                        TenNv=c.Ten,
                        Sdt = b.SDT,
                        DiemTichLuy = b.DiemTichLuy,
                        TTNv = c.Ten + "-" + c.Ma,

                    }
                ).ToList();
            return data;
        }

        public List<HoaDon>? GetAllView()
        {
            _lsthoaDons = _ihoaDonRepos.GetAllHD().ToList();
            return _lsthoaDons;
        }

        public List<string> TrangThai()
        {
            return new List<string>() { "Chưa thanh toán", "Đã thanh toán" };
        }

        public bool Update(HoaDonView obj)
        {
            if (obj == null) return false;
            var hoaDon = _ihoaDonRepos.GetAllHD().FirstOrDefault(c => c.Id == obj.Id);
            if (hoaDon == null) return false;

            hoaDon.Ma = obj.Ma;
            hoaDon.NgayMua = obj.NgayMua;
            hoaDon.NgayThanhToan = obj.NgayThanhToan;
            hoaDon.TrangThai = obj.TrangThai;
            hoaDon.ID_KH=obj.ID_KH;
            hoaDon.ID_NV = obj.ID_NV;
            if (_ihoaDonRepos.Update(hoaDon)) return true;
            return false;
        }
    }
}
