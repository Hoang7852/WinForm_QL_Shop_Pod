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
    public class SizeRepos : ISizeRepos
    {
        private DA1DBContext dBContext;
        public SizeRepos()
        {
            dBContext= new DA1DBContext();
        }
        public bool Add(Size size)
        {
            if (size == null)
            {
                return false;
            }
            dBContext.Sizes.Add(size);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(Size size)
        {
            if (size==null)
            {
                return false;
            }
            var obj= dBContext.Sizes.FirstOrDefault(x=>x.Id==size.Id);
            dBContext.Sizes.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<Size> GetAllSize()
        {
            return dBContext.Sizes.ToList();
        }

        public bool Update(Size size)
        {
            if (size == null)
            {
                return false;
            }
            var obj = dBContext.Sizes.FirstOrDefault(x => x.Id == size.Id);
            obj.Id = size.Id;
            obj.Ma=size.Ma;
            obj.Ten=size.Ten;
            dBContext.Sizes.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
