using _1._DAL.IRepository;
using _1._DAL.Models;
using _1._DAL.Repository;
using _2._BUS.IServices;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.Services
{
    public class BaoCaoService : IBaoCaoService
    {
        private IBaoCaoRepos _ibaoCaoRepos;
        private List<BaoCao> _lstbaoCaos;
        public BaoCaoService()
        {
            _ibaoCaoRepos = new BaoCaoRepos();
            _lstbaoCaos = new List<BaoCao>();
        }
        public bool Add(BaoCaoView obj)
        {
            if (obj == null) return false;
            var bc = new BaoCao()
            {
                Id = obj.Id,
                Ma=obj.Ma,
                Ngay = obj.Ngay,
                DoanhThu = obj.DoanhThu,
            };
            if (_ibaoCaoRepos.Add(bc)) return true;
            return false;
        }

        public List<BaoCaoView> GetAllKH()
        {
            List<BaoCaoView> lst = new List<BaoCaoView>();
            lst =
                (
                    from a in _ibaoCaoRepos.GetAllBC()
                    select new BaoCaoView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ngay = a.Ngay,
                        DoanhThu = a.DoanhThu,
                    }
                ).ToList();
            return lst;
        }

        public BaoCao GetById(Guid id)
        {
            return _ibaoCaoRepos.GetAllBC().FirstOrDefault(c => c.Id == id);
        }

        public bool Update(BaoCaoView obj)
        {
            if (obj == null) return false;
            var bc = _ibaoCaoRepos.GetAllBC().FirstOrDefault(c => c.Id == obj.Id);
            bc.Ma=obj.Ma;
            bc.Ngay = obj.Ngay;
            bc.DoanhThu = obj.DoanhThu;
            if (_ibaoCaoRepos.Update(bc)) return true;
            return false;
        }
    }
}
