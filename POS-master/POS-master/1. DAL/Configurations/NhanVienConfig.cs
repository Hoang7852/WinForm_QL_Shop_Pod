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
    public class NhanVienConfig : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ma).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Ten).IsUnicode(true).HasMaxLength(100).IsRequired();
            builder.Property(x => x.DiaChi).IsUnicode(true).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LinkAnh).HasMaxLength(256).IsRequired();
        }
    }
}
