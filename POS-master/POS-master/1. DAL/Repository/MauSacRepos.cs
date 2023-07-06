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
    public class MauSacRepos : IMauSacRepos
    {
        private DA1DBContext dBContext;
        public MauSacRepos()
        {
            dBContext=new DA1DBContext();
        }
        public bool Add(MauSac mauSac)
        {
            if (mauSac==null)
            {
                return false;
            }
            dBContext.MauSacs.Add(mauSac);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(MauSac mauSac)
        {
            if (mauSac==null)
            {
                return false;
            }
            var obj=dBContext.MauSacs.FirstOrDefault(x=>x.Id==mauSac.Id);
            dBContext.MauSacs.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<MauSac> GetAllMS()
        {
            return dBContext.MauSacs.ToList();
        }

        public bool Update(MauSac mauSac)
        {
            if (mauSac==null)
            {
                return false;
            }
            var obj=dBContext.MauSacs.FirstOrDefault(x=>x.Id == mauSac.Id);
            obj.Id = mauSac.Id;
            obj.Ma=mauSac.Ma;
            obj.Ten=mauSac.Ten;
            dBContext.MauSacs.Update(mauSac);
            dBContext.SaveChanges();
            return true;
        }
    }
}
