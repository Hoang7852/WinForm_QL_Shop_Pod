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
    public class HoaDonRepos : IHoaDonRepos
    {
        private DA1DBContext dBContext;
        public HoaDonRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(HoaDon hoaDon)
        {
            if (hoaDon == null)
            {
                return false;
            }
            dBContext.HoaDons.Add(hoaDon);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDon hoaDon)
        {
            if (hoaDon==null)
            {
                return false;
            }
            var obj=dBContext.HoaDons.FirstOrDefault(x=>x.Id==hoaDon.Id);
            dBContext.HoaDons.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAllHD()
        {
            return dBContext.HoaDons.ToList();
        }

        public bool Update(HoaDon hoaDon)
        {
            if (hoaDon==null)
            {
                return false;
            }
            var obj=dBContext.HoaDons.FirstOrDefault(x=>x.Id == hoaDon.Id);
            obj.Id= hoaDon.Id;
            obj.Ma=hoaDon.Ma;
            obj.NgayMua= hoaDon.NgayMua;
            obj.NgayThanhToan=hoaDon.NgayThanhToan;
            obj.TrangThai= hoaDon.TrangThai;
            dBContext.HoaDons.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
