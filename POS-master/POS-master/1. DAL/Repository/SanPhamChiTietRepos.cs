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
    public class SanPhamChiTietRepos : ISanPhamChiTietRepos
    {
        private DA1DBContext dBContext;
        public SanPhamChiTietRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(SanPhamChiTiet sanPhamChiTiet)
        {
            if (sanPhamChiTiet==null)
            {
                return false;
            }
            dBContext.SanPhamChiTiets.Add(sanPhamChiTiet);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(SanPhamChiTiet sanPhamChiTiet)
        {
            if (sanPhamChiTiet==null)
            {
                return false;
            }
            var obj=dBContext.SanPhamChiTiets.FirstOrDefault(x=>x.Id==sanPhamChiTiet.Id);
            dBContext.SanPhamChiTiets.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<SanPhamChiTiet> GetAllSPCT()
        {
            return dBContext.SanPhamChiTiets.ToList();
        }

        public bool Update(SanPhamChiTiet sanPhamChiTiet)
        {
            if (sanPhamChiTiet==null)
            {
                return false;
            }
            var obj=dBContext.SanPhamChiTiets.FirstOrDefault(x=>x.Id==sanPhamChiTiet.Id);
            obj.Id = sanPhamChiTiet.Id;
            obj.Ma=sanPhamChiTiet.Ma;
            obj.MoTa = sanPhamChiTiet.MoTa;
            obj.GiaNiemYet= sanPhamChiTiet.GiaNiemYet;
            obj.SoLuongTon = sanPhamChiTiet.SoLuongTon;
            obj.LinkAnh= sanPhamChiTiet.LinkAnh;
            obj.MaVach = sanPhamChiTiet.MaVach;
            dBContext.SanPhamChiTiets.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
