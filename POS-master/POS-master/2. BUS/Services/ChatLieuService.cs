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
    public class ChatLieuService : IChatLieuService
    {
        private IChatLieuRepos _ichatLieuRepos; 
        public ChatLieuService()
        {
            _ichatLieuRepos=new ChatLieuRepos();
        }
        public bool Add(ChatLieuView obj)
        {
            if (obj == null) return false;
            var size = new ChatLieu()
            {
                Ten = obj.Ten,
                Ma = obj.Ma,
            };
            if (_ichatLieuRepos.Add(size)) return true;
            return false;
        }

        public bool Delete(ChatLieuView obj)
        {
            if (obj == null) return false;
            var size = _ichatLieuRepos.GetAllCL().FirstOrDefault(c => c.Ten == obj.Ten);
            if (_ichatLieuRepos.Delete(size)) return true;
            return false;
        }

        public List<ChatLieuView> GetAll()
        {
            List<ChatLieuView> lst = new List<ChatLieuView>();
            lst =
                (
                    from a in _ichatLieuRepos.GetAllCL()
                    select new ChatLieuView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                    }
                ).ToList();
            return lst;
        }

        public ChatLieu GetById(Guid id)
        {
            return _ichatLieuRepos.GetAllCL().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)   
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public bool Update(ChatLieuView obj)
        {
            if (obj == null) return false;
            var size = _ichatLieuRepos.GetAllCL().FirstOrDefault(c => c.Id == obj.Id);
            size.Ma=obj.Ma;
            size.Ten = obj.Ten;
            if (_ichatLieuRepos.Update(size)) return true;
            return false;
        }
    }
}
