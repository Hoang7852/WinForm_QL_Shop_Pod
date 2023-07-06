using _1._DAL.Models;
using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface IChatLieuService
    {
        bool Add(ChatLieuView obj);
        bool Update(ChatLieuView obj);
        bool Delete(ChatLieuView obj);
        ChatLieu GetById(Guid id);
        Guid GetIdByName(string input);
        List<ChatLieuView> GetAll();
    }
}
