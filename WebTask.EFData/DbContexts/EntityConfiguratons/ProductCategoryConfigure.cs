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
    public class ProductCategoryConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("productCategories");
            builder.Property(e => e.Id).HasColumnName("category_id");
            builder.Property(e => e.CreatedDate).HasColumnName("category_datecreated").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.ModifiedDate).HasColumnName("category_datemodified").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.Name).IsRequired().HasColumnName("category_name").HasColumnType("varchar(20)").HasDefaultValueSql("('')");
        }
    }
}
