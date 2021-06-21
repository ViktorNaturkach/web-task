using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTask.Common;
using WebTask.EFData.DbContexts.SeedData;
using WebTask.EFData.Repositories;
using WebTask.Infrastructure;
using WebTask.Infrastructure.Interfaces.Repository;

namespace WebTask.EFData
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEFDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            services.AddDbContext<AppDbContext>(options =>
                   options
                   .EnableSensitiveDataLogging()
                   .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("WebTask.EFData")));

            services.AddIdentity<User, IdentityRole>()
                          .AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie((options) =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Home/Error";
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(EFBaseRepository<>));
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ITypeRepository, EFTypeRepository>();
            services.AddScoped<ISizeRepository, EFSizeRepository>();
            return services;
        }

    }
}
