using _2._BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.IServices
{
    public interface ITaiKhoanService
    {
        bool Add(NhanVienView obj);
        bool Update(NhanVienView obj);
        bool Delete(NhanVienView obj);
        List<NhanVienView>? GetAll(string? input);

        List<NhanVienView>? GetAll();
        List<NhanVienView>? GetAllQuanLi();
    }
}
