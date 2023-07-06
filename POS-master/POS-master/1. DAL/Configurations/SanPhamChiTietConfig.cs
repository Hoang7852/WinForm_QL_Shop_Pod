using _1._DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._DAL.Configurations
{
    public class SanPhamChiTietConfig : IEntityTypeConfiguration<SanPhamChiTiet>
    {
        public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasMaxLength(20).IsRequired();
            builder.Property(x => x.MoTa).IsUnicode(true).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.LinkAnh).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.MaVach).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.ChatLieu).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_CL);
            builder.HasOne(x => x.Size).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_Size);
            builder.HasOne(x => x.Loai).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_Loai);
            builder.HasOne(x => x.MauSac).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_MauSac);
            builder.HasOne(x => x.NSX).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_NSX);
            builder.HasOne(x => x.SanPham).WithMany(x => x.SanPhamChiTiets).HasForeignKey(x => x.ID_SP);
        }
    }
}
