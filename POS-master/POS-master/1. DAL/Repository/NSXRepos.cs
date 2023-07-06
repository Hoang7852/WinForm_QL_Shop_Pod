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
    public class NSXRepos : INSXRepos
    {
        private DA1DBContext dBContext;
        public NSXRepos()
        {
            dBContext= new DA1DBContext();
        }
        public bool Add(NSX nSX)
        {
            if (nSX == null)
            {
                return false;
            }
            dBContext.NSXes.Add(nSX);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(NSX nSX)
        {
            if (nSX ==null)
            {
                return false;
            }
            var obj = dBContext.NSXes.FirstOrDefault(x=>x.Id==nSX.Id);
            dBContext.NSXes.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<NSX> GetAllNSX() 
        {
            return dBContext.NSXes.ToList();
        }

        public bool Update(NSX nSX)
        {
            if (nSX ==null)
            {
                return false;
            }
            var obj = dBContext.NSXes.FirstOrDefault(x => x.Id == nSX.Id);
            obj.Id= nSX.Id;
            obj.Ma=nSX.Ma;
            obj.Ten=nSX.Ten;
            dBContext.NSXes.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
