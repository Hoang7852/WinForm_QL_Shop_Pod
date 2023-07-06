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
    public class LoaiRepos : ILoaiRepos
    {
        private DA1DBContext dBContext;
        public LoaiRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(Loai loai)
        {
            if (dBContext == null)
            {
                return false;
            }
            dBContext.Loais.Add(loai);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(Loai loai)
        {
            if (loai==null)
            {
                return false;
            }
            var obj=dBContext.Loais.FirstOrDefault(x=>x.Id==loai.Id);
            dBContext.Loais.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<Loai> GetAllLoai()
        {
            return dBContext.Loais.ToList();
        }

        public bool Update(Loai loai)
        {
            if (loai==null)
            {
                return false;
            }
            var obj = dBContext.Loais.FirstOrDefault(x => x.Id == loai.Id);
            obj.Id=loai.Id;
            obj.Ma=loai.Ma;
            obj.Ten=loai.Ten;
            dBContext.Loais.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
