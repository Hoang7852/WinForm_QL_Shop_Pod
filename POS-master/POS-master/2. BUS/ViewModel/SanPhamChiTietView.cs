using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._BUS.ViewModel
{
    public class SanPhamChiTietView
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public string LinkAnh { get; set; }
        public int SoLuongTon { get; set; }


        public string TenChatLieu { get; set; }
        public string TenSize { get; set; }
        public string TenLoai { get; set; }
        public string TenMauSac { get; set; }
        public string TenNsx { get; set; }
        public string TenSp { get; set; }
        public int TrangThai { get; set; }
        public double Gia { get; set; }
        public float GiaNhap { get; set; }
        public string MaVach { get; set; }


        public Guid ID_CL { get; set; }
        public Guid ID_Loai { get; set; }
        public Guid ID_NSX { get; set; }
        public Guid ID_Size { get; set; }
        public Guid ID_MauSac { get; set; }
        public Guid ID_SP { get; set; }
    }
}
