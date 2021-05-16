using Microsoft.EntityFrameworkCore;
using WebTask.Common;
using WebTask.EFData.DbContexts.EntityConfiguratons;

namespace WebTask.EFData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductCinfigure());

		}
		public DbSet<Product> Products { get; set; }
    }
}
