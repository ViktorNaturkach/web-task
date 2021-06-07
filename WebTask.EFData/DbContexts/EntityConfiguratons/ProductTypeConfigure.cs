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
    public class ProductTypeConfigure : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("productTypes");
            builder.Property(e => e.Id).HasColumnName("type_id");
            builder.Property(e => e.CreatedDate).HasColumnName("type_datecreated").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.ModifiedDate).HasColumnName("type_datemodified").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.Name).IsRequired().HasColumnName("type_name").HasColumnType("varchar(20)").HasDefaultValueSql("('')");
        }
    }
}
