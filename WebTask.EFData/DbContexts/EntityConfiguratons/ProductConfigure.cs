using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTask.Common;

namespace WebTask.EFData.DbContexts.EntityConfiguratons
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
    

        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder .HasKey(e => e.Id);
			builder.ToTable("products");
            builder.Property(e => e.Id).HasColumnName("prod_id");
            builder.Property(e => e.CreatedDate).HasColumnName("prod_datecreated").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.ModifiedDate).HasColumnName("prod_datemodified").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.Name).IsRequired().HasColumnName("prod_name").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
			builder.Property(e => e.Description).IsRequired().HasColumnName("prod_description").HasColumnType("varchar(100)").HasDefaultValueSql("('')");
			builder.Property(e => e.Price).HasColumnName("prod_price").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
			builder.Property(e => e.SalePrice).HasColumnName("prod_saleprice").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
            builder.Property(e => e.SaleEndDate).HasColumnName("prod_saleenddate").HasColumnType("datetime").HasDefaultValueSql("(sysdatetime())");
            builder.Property(e => e.ImageSrc).IsRequired().HasColumnName("prod_imgsrc").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
        }
	}
}
