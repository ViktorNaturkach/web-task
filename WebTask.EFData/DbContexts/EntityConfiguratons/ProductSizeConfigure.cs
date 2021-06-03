using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;

namespace WebTask.EFData.DbContexts.EntityConfiguratons
{
    class ProductSizeConfigure : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("productSizes");
            builder.Property(e => e.Id).HasColumnName("size_id");
            builder.Property(e => e.Name).IsRequired().HasColumnName("size_name").HasColumnType("varchar(5)").HasDefaultValueSql("('')");
        }
    }
}
