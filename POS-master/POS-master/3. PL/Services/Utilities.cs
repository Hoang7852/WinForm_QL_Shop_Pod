using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3._PL.Services
{
    public class Utilities
    {
        public static string CheckEmpty(string s)
        {
            if (s.Trim().Length == 0)
            {
                return "Không được để trống *";
            }
            return "";
        }
        public static string CheckSdt(string s)
        {
            string strRegex = @"(^0[0-9]{9})";
            Regex r = new Regex(strRegex);
            if (r.IsMatch(s))
            {
                return "";
            }
            return "Vui lòng nhập đúng 10 số và bắt đầu = số 0";
        }
        public string CheckMk(string s)
        {
            string strRegex = @"(\w)(?=.*[A-Z]).{5,}";
            Regex r = new Regex(strRegex);
            if (r.IsMatch(s))
            {
                return "";
            }
            return "Vui lòng nhập đúng mật khẩu gồm 6 kí tự và phải có 1 chữ in hoa";
        }
        public string CheckEmail(string s)
        {
            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex r = new Regex(strRegex);
            if (r.IsMatch(s))
            {
                return "";
            }
            return "Vui lòng nhập đúng định dạng email";
        }
        public string CheckNumber(string s)
        {
            string strRegex = @"^[0-9]*$";
            Regex r = new Regex(strRegex);
            if (r.IsMatch(s))
            {
                return "";
            }
            return "Vui lòng nhập số";
        }
    }
}
