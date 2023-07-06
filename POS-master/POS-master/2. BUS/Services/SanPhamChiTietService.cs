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
    public class SanPhamChiTietService : ISanPhamChiTietService
    {
        private ISanPhamChiTietRepos _isanPhamChiTietRepos;
        private ISanPhamRepos _isanPhamRepos;
        private ILoaiRepos _iloaiRepos;
        private INSXRepos _inSXRepos;
        private IMauSacRepos _imauSacRepos;
        private ISizeRepos _isizeRepos;
        private IChatLieuRepos _ichatLieuRepos;
        public SanPhamChiTietService()
        {
            _isanPhamChiTietRepos = new SanPhamChiTietRepos();
            _isanPhamRepos = new SanPhamRepos();
            _iloaiRepos = new LoaiRepos();
            _inSXRepos = new NSXRepos();
            _imauSacRepos = new MauSacRepos();
            _isizeRepos = new SizeRepos();
            _ichatLieuRepos = new ChatLieuRepos();
        }
        public bool Add(SanPhamChiTietView obj)
        {
            if (obj == null) return false;
            var p = new SanPham()
            {
                Id = obj.Id,
                Ma = obj.Ma,
                Ten = obj.TenSp,
                TrangThai=obj.TrangThai,
            };
            _isanPhamRepos.Add(p);

            var x = new SanPhamChiTiet()
            {
                Id = obj.Id,
                Ma=obj.Ma,
                ID_SP = obj.Id,
                ID_Loai = obj.ID_Loai,
                ID_NSX = obj.ID_NSX,
                ID_MauSac = obj.ID_MauSac,
                ID_CL = obj.ID_CL,
                ID_Size = obj.ID_Size,
                SoLuongTon = obj.SoLuongTon,
                MoTa = obj.MoTa,
                LinkAnh = obj.LinkAnh,
                GiaNhap = obj.GiaNhap,
                GiaNiemYet = obj.Gia,
                MaVach = obj.MaVach,
            };
            _isanPhamChiTietRepos.Add(x);

            return true;
        }

        public bool Delete(SanPhamChiTietView obj)
        {
            if (obj == null) return false;
            var chiTietSp = _isanPhamChiTietRepos.GetAllSPCT().FirstOrDefault(c => c.Id == obj.Id);
            if (_isanPhamChiTietRepos.Delete(chiTietSp)) return true;
            return false;
        }

        public List<SanPhamChiTietView> GetAll()
        {
            List<SanPhamChiTietView> lstSPViews = new List<SanPhamChiTietView>();
            lstSPViews =
                (
                    from a in _isanPhamChiTietRepos.GetAllSPCT()
                    join b in _imauSacRepos.GetAllMS() on a.ID_MauSac equals b.Id
                    join c in _iloaiRepos.GetAllLoai() on a.ID_Loai equals c.Id
                    join d in _inSXRepos.GetAllNSX() on a.ID_NSX equals d.Id
                    join e in _isanPhamRepos.GetAllSP() on a.ID_SP equals e.Id
                    join r in _ichatLieuRepos.GetAllCL() on a.ID_CL equals r.Id
                    join t in _isizeRepos.GetAllSize() on a.ID_Size equals t.Id
                    select new SanPhamChiTietView()
                    {
                        Id = a.Id,
                        ID_SP = e.Id,
                        ID_MauSac = b.Id,
                        ID_Loai = c.Id,
                        ID_CL = r.Id,
                        ID_Size = t.Id,
                        ID_NSX = d.Id,
                        Ma = a.Ma,
                        SoLuongTon = a.SoLuongTon,
                        MoTa = a.MoTa,
                        LinkAnh = a.LinkAnh,
                        MaVach = a.MaVach,
                        TrangThai = e.TrangThai,
                        Gia=a.GiaNiemYet,
                        GiaNhap=a.GiaNhap,
                        TenChatLieu = r.Ten,
                        TenSize = t.Ten,
                        TenLoai = c.Ten,
                        TenMauSac = b.Ten,
                        TenNsx = d.Ten,
                        TenSp = e.Ten,
                    }
                ).ToList();
            return lstSPViews;
        }

        public string? GetMaByID(Guid? id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id).Ma;
        }

        public SanPhamChiTiet? GETMASP(string? input)
        {
            return _isanPhamChiTietRepos.GetAllSPCT().FirstOrDefault(c => c.Ma == input);
        }

        public string? GETNAME(string? input)
        {
            return GetAll().FirstOrDefault(c => c.Ma == input).TenSp;
        }

        public bool Update(SanPhamChiTietView obj)
        {
            if (obj == null) return false;
            var sanPham = _isanPhamRepos.GetAllSP().FirstOrDefault(c=>c.Id==obj.ID_SP);
            sanPham.Ten = obj.TenSp;
            sanPham.TrangThai = obj.TrangThai;
            var chiTietSp = _isanPhamChiTietRepos.GetAllSPCT().FirstOrDefault(c => c.Id == obj.Id);
            chiTietSp.ID_SP = obj.ID_SP;
            chiTietSp.Ma=obj.Ma;
            chiTietSp.ID_Loai = obj.ID_Loai;
            chiTietSp.ID_MauSac = obj.ID_MauSac;
            chiTietSp.ID_NSX = obj.ID_NSX;
            chiTietSp.ID_Size = obj.ID_Size;
            chiTietSp.ID_CL = obj.ID_CL;
            chiTietSp.SoLuongTon = obj.SoLuongTon;
            chiTietSp.GiaNhap = obj.GiaNhap;
            chiTietSp.GiaNiemYet = obj.Gia;
            chiTietSp.LinkAnh = obj.LinkAnh;
            chiTietSp.MaVach=obj.MaVach;
            chiTietSp.MoTa = obj.MoTa;
            if (_isanPhamChiTietRepos.Update(chiTietSp)) return true;
            return false;
        }
    }
}
