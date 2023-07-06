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
    public class HoaDonChiTietConfig : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ma).HasMaxLength(20).IsRequired();
            builder.HasOne(x => x.HoaDon).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.ID_HD);
            builder.HasOne(x => x.SanPhamChiTiet).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.ID_SPCT);
        }
    }
}
