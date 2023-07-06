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
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ma).HasMaxLength(20).IsRequired();
            builder.HasOne(x=>x.NhanViens).WithMany(x=>x.HoaDons).HasForeignKey(x=>x.ID_NV);
            builder.HasOne(x=>x.KhachHang).WithMany(x=>x.HoaDons).HasForeignKey(x=>x.ID_KH);
        }
    }
}
