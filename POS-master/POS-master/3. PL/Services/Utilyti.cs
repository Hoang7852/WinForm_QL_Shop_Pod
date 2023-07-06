using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _3._PL.Services
{
    public class Utilyti
    {
        // Nguyễn Minh Đức => ducnm
        public static string GetMaTuSinh(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            string temp = value.Trim().ToLower(); //Cắt khoảng trắng 2 đầu và đưa về chữ thường. => nguyễn minh đức
            string[] arrNames = temp.Split(' '); //Cắt chuỗi về mảng
            string final = GetVietHoaChuCaiDau(arrNames[arrNames.Length - 1]).Trim(); //Duc
            for (int i = 0; i < arrNames.Length - 1; i++)
            {
                final += GetChuCaiDau(arrNames[i]);
            }

            return ConvertToUnsign(final); //Ducnm
        }

        public static string VietHoaChuCaiDau(string value) //nguyễn Minh Đức
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            string temp = value.Trim().ToLower(); //Cắt khoảng trắng 2 đầu và đưa về chữ thường. => nguyễn minh đức
            string[] arrNames = temp.Split(' '); //Cắt chuỗi về mảng
            string final = ""; //Duc
            for (int i = 0; i < arrNames.Length; i++)
            {
                final += GetVietHoaChuCaiDau(arrNames[i]);
            }

            return final; //Ducnm
        }

        public static string GetChuCaiDau(string value) //nguyễn
        {
            return Convert.ToString(value[0]); //= n
        }

        public static string GetVietHoaChuCaiDau(string value)//nguyễn
        {
            return Convert.ToString(value[0]).ToUpper() + value.Substring(1) + " ";//= Nguyễn
        }

        //Loại bỏ tiếng việt
        private static Regex ConvertToUnsign_rg = null;

        public static string ConvertToUnsign(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    
    }   
}
