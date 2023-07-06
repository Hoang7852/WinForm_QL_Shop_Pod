    using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using _1._DAL.Models;

namespace _1._DAL.DBcontext
{
    public class DA1DBContext:DbContext
    {
        public DA1DBContext()
        {
            
        }

        public DA1DBContext(DbContextOptions<DA1DBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MinhDuc\SQLEXPRESS;Initial Catalog=DuAn1;Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public virtual DbSet<ChatLieu> ChatLieus { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NSX> NSXes { get; set; }
    }
}
