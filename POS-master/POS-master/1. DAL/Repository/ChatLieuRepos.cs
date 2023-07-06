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
    public class ChatLieuRepos : IChatLieuRepos
    {
        private DA1DBContext dBContext;
        public ChatLieuRepos()
        {
            dBContext = new DA1DBContext();
        }
        public bool Add(ChatLieu chatLieu)
        {
            if (chatLieu == null)
            {
                return false;
            }
            dBContext.ChatLieus.Add(chatLieu);
            dBContext.SaveChanges();
            return true;
        }

        public bool Delete(ChatLieu chatLieu)
        {
            if (chatLieu == null)
            {
                return false;
            }
            var obj=dBContext.ChatLieus.FirstOrDefault(x => x.Id== chatLieu.Id);
            dBContext.ChatLieus.Remove(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<ChatLieu> GetAllCL()
        {
            return dBContext.ChatLieus.ToList();
        }

        public bool Update(ChatLieu chatLieu)
        {
            if (chatLieu == null)
            {
                return false;
            }
            var obj=dBContext.ChatLieus.FirstOrDefault(x=>x.Id==chatLieu.Id);
            obj.Id = chatLieu.Id;
            obj.Ma=chatLieu.Ma;
            obj.Ten = chatLieu.Ten;
            dBContext.ChatLieus.Update(chatLieu);
            dBContext.SaveChanges();
            return true;
        }
    }
}
