using _1._DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.IRepository
{
    public interface IChatLieuRepos
    {
        bool Add(ChatLieu chatLieu);
        bool Update(ChatLieu chatLieu);
        bool Delete(ChatLieu chatLieu);
        List<ChatLieu> GetAllCL();
    }
}
