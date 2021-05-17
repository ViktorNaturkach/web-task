using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTask.Common;
using WebTask.Infrastructure;

namespace WebTask.EFData
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEFDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<User, IdentityRole>()
                          .AddEntityFrameworkStores<IdentityContext>();

            services.AddScoped<IProductRepository, EFProductRepository>();
            return services;
        }

    }
}
