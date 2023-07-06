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
    public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasMaxLength(20).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PassWord).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.NhanVien).WithOne(x => x.TaiKhoan).HasForeignKey<TaiKhoan>(x=>x.Id_NV);
        }
    }
}
