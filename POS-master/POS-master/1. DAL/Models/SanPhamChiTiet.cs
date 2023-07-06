using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Models
{
    public class SanPhamChiTiet
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public double GiaNiemYet { get; set; }
        public float GiaNhap { get; set; }
        public string LinkAnh { get; set; }
        public string MaVach { get; set; }
        public Guid ID_CL { get; set; }
        public Guid ID_Loai { get; set; }
        public Guid ID_NSX { get; set; }
        public Guid ID_Size { get; set; }
        public Guid ID_MauSac { get; set; }
        public Guid ID_SP { get; set; }
        public virtual ChatLieu ChatLieu { get; set; }
        public virtual Loai Loai { get; set; }
        public virtual NSX NSX { get; set; }
        public virtual Size Size { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
