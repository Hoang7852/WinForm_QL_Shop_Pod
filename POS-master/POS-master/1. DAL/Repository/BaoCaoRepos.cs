using _1._DAL.DBcontext;
using _1._DAL.IRepository;
using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Repository
{
    public class BaoCaoRepos : IBaoCaoRepos
    {
        private DA1DBContext dBContext;
        public BaoCaoRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(BaoCao baoCao)
        {
            if (baoCao == null)
            {
                return false;
            }
            dBContext.BaoCaos.Add(baoCao);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(BaoCao baoCao)
        {
            if (baoCao==null)
            {
                return false;
            }
            var obj = dBContext.BaoCaos.FirstOrDefault(x => x.Id == baoCao.Id);
            dBContext.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<BaoCao> GetAllBC()
        {
            return dBContext.BaoCaos.ToList();
        }

        public bool Update(BaoCao baoCao)
        {
            if (baoCao==null)
            {
                return false;
            }
            var obj=dBContext.BaoCaos.FirstOrDefault(x=>x.Id == baoCao.Id);
            obj.Id = baoCao.Id;
            obj.Ma=baoCao.Ma;
            obj.Ngay = baoCao.Ngay;
            obj.DoanhThu=baoCao.DoanhThu;
            dBContext.BaoCaos.Update(obj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
