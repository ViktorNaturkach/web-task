using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.ProductID);
				entity.ToTable("products");
				entity.Property(e => e.ProductID).HasColumnName("prod_id");
				entity.Property(e => e.DateCreated).HasColumnName("prod_datecreated").HasColumnType("datetimeoffset").HasDefaultValueSql("(sysdatetimeoffset())");
				entity.Property(e => e.Name).IsRequired().HasColumnName("prod_name").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
				entity.Property(e => e.Description).IsRequired().HasColumnName("prod_description").HasColumnType("varchar(100)").HasDefaultValueSql("('')");
				entity.Property(e => e.Price).HasColumnName("prod_price").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
				entity.Property(e => e.SalePrice).HasColumnName("prod_saleprice").HasColumnType("decimal(7,2)").HasDefaultValueSql("(0)");
				entity.Property(e => e.SaleEndDate).HasColumnName("prod_saleenddate").HasColumnType("datetimeoffset").HasDefaultValueSql("(sysdatetimeoffset())");
				entity.Property(e => e.Category).IsRequired().HasColumnName("prod_category").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
				entity.Property(e => e.Brand).IsRequired().HasColumnName("prod_brand").HasColumnType("varchar(60)").HasDefaultValueSql("('')");
				entity.Property(e => e.Tag).IsRequired().HasColumnName("prod_tag").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
				entity.Property(e => e.Color).IsRequired().HasColumnName("prod_color").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
				entity.Property(e => e.Size).IsRequired().HasColumnName("prod_size").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
				entity.Property(e => e.ImageSrc).IsRequired().HasColumnName("prod_imgsrc").HasColumnType("varchar(300)").HasDefaultValueSql("('')");
			});
		}
		public DbSet<Product> Products { get; set; }
    }
}
