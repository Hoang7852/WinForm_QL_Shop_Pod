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
    public class BaoCaoConfig : IEntityTypeConfiguration<BaoCao>
    {
        public void Configure(EntityTypeBuilder<BaoCao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ma).HasMaxLength(20).IsRequired();
        }
    }
}
