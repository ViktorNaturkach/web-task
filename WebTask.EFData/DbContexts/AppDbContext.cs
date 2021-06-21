using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTask.Common;
using WebTask.Common.Entities;
using WebTask.EFData.DbContexts.EntityConfiguratons;

namespace WebTask.EFData
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfigure());
            modelBuilder.ApplyConfiguration(new ProductSizeConfigure());
            modelBuilder.ApplyConfiguration(new ProductTypeConfigure());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfigure());
        }
		public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> Types { get; set; }
    }
}
