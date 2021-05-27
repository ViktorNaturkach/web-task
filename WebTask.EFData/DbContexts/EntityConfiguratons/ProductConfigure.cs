using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTask.Common;

namespace WebTask.EFData.DbContexts.EntityConfiguratons
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
    

        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder .HasKey(e => e.ProductID);
			builder.ToTable("products");
			builder.Property(e => e.ProductID).HasColumnName("prod_id");
			builder.Property(e => e.DateCreated).HasColumnName("prod_datecreated").HasColumnType("datetimeoffset").HasDefaultValueSql("(sysdatetimeoffset())");
			builder.Property(e => e.Name).IsRequired().HasColumnName("prod_name").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
			builder.Property(e => e.Description).IsRequired().HasColumnName("prod_description").HasColumnType("varchar(100)").HasDefaultValueSql("('')");
			builder.Property(e => e.Price).HasColumnName("prod_price").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
			builder.Property(e => e.SalePrice).HasColumnName("prod_saleprice").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
            builder.Property(e => e.SaleEndDate).HasColumnName("prod_saleenddate").HasColumnType("datetimeoffset").HasDefaultValueSql("(sysdatetimeoffset())");
            builder.Property(e => e.Category).IsRequired().HasColumnName("prod_category").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
            builder.Property(e => e.Brand).IsRequired().HasColumnName("prod_brand").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
            builder.Property(e => e.Tag).IsRequired().HasColumnName("prod_tag").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
            builder.Property(e => e.Color).IsRequired().HasColumnName("prod_color").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
            builder.Property(e => e.Size).IsRequired().HasColumnName("prod_size").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
            builder.Property(e => e.ImageSrc).IsRequired().HasColumnName("prod_imgsrc").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
        }
	}
}
