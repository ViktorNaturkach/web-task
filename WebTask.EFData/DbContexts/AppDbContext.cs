﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTask.Common;
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
        }
		public DbSet<Product> Products { get; set; }
    }
}
