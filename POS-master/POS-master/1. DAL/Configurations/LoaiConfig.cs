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
    public class LoaiConfig : IEntityTypeConfiguration<Loai>
    {
        public void Configure(EntityTypeBuilder<Loai> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Ten).IsUnicode(true).HasMaxLength(50).IsRequired();
        }
    }
}
