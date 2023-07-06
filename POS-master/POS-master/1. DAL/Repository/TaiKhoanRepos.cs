using _1._DAL.DBcontext;
using _1._DAL.IRepository;
using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Repository
{
    public class TaiKhoanRepos : ITaiKhoanRepos
    {
        private DA1DBContext dBContext;
        public TaiKhoanRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(TaiKhoan taiKhoan)
        {
            if (taiKhoan == null)
            {
                return false;
            }
            dBContext.TaiKhoans.Add(taiKhoan);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(TaiKhoan taiKhoan)
        {
            if (taiKhoan == null)
            {
                return false;
            }
            var obj = dBContext.TaiKhoans.FirstOrDefault(x=>x.Id == taiKhoan.Id);
            dBContext.TaiKhoans.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<TaiKhoan> GetAllTK()
        {
            return dBContext.TaiKhoans.ToList();
        }

        public bool Update(TaiKhoan taiKhoan)
        {
            if (taiKhoan == null)
            {
                return false;
            }
            var obj = dBContext.TaiKhoans.FirstOrDefault(x => x.Id == taiKhoan.Id);
            obj.Id= taiKhoan.Id;
            obj.Ma=taiKhoan.Ma;
            obj.UserName= taiKhoan.UserName;
            obj.PassWord= taiKhoan.PassWord;
            obj.ChucVu=taiKhoan.ChucVu;
            obj.TrangThai=taiKhoan.TrangThai;
            dBContext.TaiKhoans.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
