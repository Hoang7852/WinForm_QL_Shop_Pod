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
    public class NhanVienRepos : INhanVienRepos
    {
        private DA1DBContext dBContext;
        public NhanVienRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(NhanVien nhanVien)
        {
            if (nhanVien==null)
            {
                return false;
            }
            dBContext.NhanViens.Add(nhanVien);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(NhanVien nhanVien)
        {
            if (nhanVien==null)
            {
                return false;
            }
            var obj=dBContext.NhanViens.FirstOrDefault(x=>x.ID==nhanVien.ID);
            dBContext.NhanViens.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAllNV()
        {
            return dBContext.NhanViens.ToList();
        }

        public bool Update(NhanVien nhanVien)
        {
            if (nhanVien==null)
            {
                return false;
            }
            var obj=dBContext.NhanViens.FirstOrDefault(x=>x.ID==nhanVien.ID);
            obj.ID= nhanVien.ID;
            obj.Ma= nhanVien.Ma;
            obj.Ten = nhanVien.Ten;
            obj.SDT = nhanVien.SDT;
            obj.DiaChi=nhanVien.DiaChi;
            obj.LinkAnh= nhanVien.LinkAnh;
            obj.TrangThai=nhanVien.TrangThai;
            dBContext.NhanViens.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
