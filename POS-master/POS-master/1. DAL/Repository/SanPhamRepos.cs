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
    public class SanPhamRepos : ISanPhamRepos
    {
        private DA1DBContext dBContext;
        public SanPhamRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(SanPham sanPham)
        {
            if (sanPham == null)
            {
                return false;
            }
            dBContext.SanPhams.Add(sanPham);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(SanPham sanPham)
        {
            if (sanPham==null)
            {
                return false;
            }
            var obj=dBContext.SanPhams.FirstOrDefault(x=>x.Id==sanPham.Id);
            dBContext.SanPhams.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<SanPham> GetAllSP()
        {
            return dBContext.SanPhams.ToList();
        }

        public bool Update(SanPham sanPham)
        {
            if (sanPham==null)
            {
                return false;
            }
            var obj=dBContext.SanPhams.FirstOrDefault(x=>x.Id == sanPham.Id);
            obj.Id = sanPham.Id;
            obj.Ma=sanPham.Ma;
            obj.Ten= sanPham.Ten;
            obj.TrangThai=sanPham.TrangThai;
            dBContext.SanPhams.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
