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
    public class KhachHangRepos : IKhachHangRepos
    {
        private DA1DBContext dBContext;
        public KhachHangRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(KhachHang khachHang)
        {
            if (khachHang == null)
            {
                return false;
            }
            dBContext.KhachHangs.Add(khachHang);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(KhachHang khachHang)
        {
            if (khachHang==null)
            {
                return false;
            }
            var obj=dBContext.KhachHangs.FirstOrDefault(x=>x.Id==khachHang.Id);
            dBContext.KhachHangs.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<KhachHang> GetAllKH()
        {
            return dBContext.KhachHangs.ToList();
        }

        public bool Update(KhachHang khachHang)
        {
            if (khachHang==null)
            {
                return false;
            }
            var obj = dBContext.KhachHangs.FirstOrDefault(x=>x.Id==khachHang.Id);
            obj.Id= khachHang.Id;
            obj.Ma= khachHang.Ma;
            obj.TenKH= khachHang.TenKH;
            obj.SDT= khachHang.SDT;
            obj.DiemTichLuy = khachHang.DiemTichLuy;
            dBContext.KhachHangs.Update(khachHang);
            dBContext.SaveChanges();
            return true;
        }
    }
}
