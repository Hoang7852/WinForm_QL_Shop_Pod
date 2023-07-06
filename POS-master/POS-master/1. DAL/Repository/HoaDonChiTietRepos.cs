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
    public class HoaDonChiTietRepos : IHoaDonChiTietRepos
    {
        private DA1DBContext dBContext;
        public HoaDonChiTietRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(HoaDonChiTiet hoaDonChiTiet)
        {
            if (hoaDonChiTiet == null)
            {
                return false;
            }
            dBContext.HoaDonChiTiets.Add(hoaDonChiTiet);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet hoaDonChiTiet)
        {
            if (hoaDonChiTiet==null)
            {
                return false;
            }
            var obj =dBContext.HoaDonChiTiets.FirstOrDefault(x=>x.Id==hoaDonChiTiet.Id);
            dBContext.HoaDonChiTiets.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> GetAllHDCT()
        {
            return dBContext.HoaDonChiTiets.ToList();
        }

        public bool Update(HoaDonChiTiet hoaDonChiTiet)
        {
            if (hoaDonChiTiet==null)
            {
                return false;
            }
            var obj=dBContext.HoaDonChiTiets.FirstOrDefault(x=>x.Id==hoaDonChiTiet.Id);
            obj.Id=hoaDonChiTiet.Id;
            obj.Ma = hoaDonChiTiet.Ma;
            obj.GiaDaGiam = hoaDonChiTiet.GiaDaGiam;
            obj.SoLuong = hoaDonChiTiet.SoLuong;
            dBContext.HoaDonChiTiets.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
