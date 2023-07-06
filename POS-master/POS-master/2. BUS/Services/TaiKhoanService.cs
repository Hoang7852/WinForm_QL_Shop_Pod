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
    public class TaiKhoanService : ITaiKhoanService
    {
        private ITaiKhoanRepos _itaiKhoanRepos;
        private INhanVienRepos _inhanVienRepos;
        public TaiKhoanService()
        {
            _itaiKhoanRepos = new TaiKhoanRepos();
            _inhanVienRepos = new NhanVienRepos();
        }

        public bool Add(NhanVienView obj)
        {
            if (obj == null) return false;
            var tk = new TaiKhoan()
            {
                Id=obj.IdTk,
                Id_NV=obj.Id_NV,
                Ma = obj.MaTk,
                UserName = obj.TaiKhoan,
                PassWord = obj.MatKhau,
                ChucVu = obj.ChucVu,
                TrangThai = obj.TrangThaiTk,

            };
            if (_itaiKhoanRepos.Add(tk)) return true;
            return false;
        }
        public bool Delete(NhanVienView obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(NhanVienView obj)
        {
            if (obj == null) return false;
            var tk = _itaiKhoanRepos.GetAllTK().FirstOrDefault(c => c.Id == obj.IdTk);
            tk.Id_NV = obj.Id_NV;
            tk.Ma = obj.MaTk;
            tk.UserName = obj.TaiKhoan;
            tk.PassWord = obj.MatKhau;
            tk.ChucVu = obj.ChucVu;
            tk.TrangThai = obj.TrangThaiTk;

            if (_itaiKhoanRepos.Update(tk)) return true;
            return false;
        }

        List<NhanVienView>? ITaiKhoanService.GetAll(string? input)
        {
            List<NhanVienView> lstTkView =
                (from a in _itaiKhoanRepos.GetAllTK()
                 join b in _inhanVienRepos.GetAllNV() on a.Id_NV equals b.ID
                 select new NhanVienView()
                 {
                     MaTk = a.Ma,
                     TaiKhoan = a.UserName,
                     MatKhau = a.PassWord,
                     ChucVu = a.ChucVu,
                     TrangThaiTk = a.TrangThai,

                 }).ToList();
            if (string.IsNullOrEmpty(input))
            {
                return lstTkView;
            }
            return lstTkView.Where(c => c.TaiKhoan.ToLower().Contains(input.ToLower())).ToList();
        }

        List<NhanVienView>? ITaiKhoanService.GetAll()
        {
            List<NhanVienView> lstTkView = new List<NhanVienView>();
            lstTkView =
                (from a in _itaiKhoanRepos.GetAllTK()
                 join b in _inhanVienRepos.GetAllNV() on a.Id_NV equals b.ID
                 select new NhanVienView()
                 {
                     IdTk = a.Id,
                     Id_NV = a.Id_NV,
                     MaTk = a.Ma,
                     TaiKhoan = a.UserName,
                     MatKhau = a.PassWord,
                     ChucVu = a.ChucVu,
                     TrangThaiTk = a.TrangThai,
                 }).ToList();
            return lstTkView;
        }

        List<NhanVienView>? ITaiKhoanService.GetAllQuanLi()
        {
            List<NhanVienView> lst = new List<NhanVienView>();
            lst =
                (
                    from a in _itaiKhoanRepos.GetAllTK()
                    select new NhanVienView()
                    {
                        IdTk = a.Id,
                        MaTk = a.Ma,
                        TaiKhoan = a.UserName,
                        MatKhau = a.PassWord,
                        ChucVu = a.ChucVu,
                        TrangThaiTk = a.TrangThai,
                    }
                ).ToList();
            return lst;
        }
    }
}
