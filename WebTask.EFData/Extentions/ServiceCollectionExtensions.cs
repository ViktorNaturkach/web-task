using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTask.EFData.Entities;

namespace WebTask.EFData
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEFDataLayer(this IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>();

            services.SameForAll();
            return services;
        }

        public static IServiceCollection AddEFDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("WebTask.EFData")));

            services.SameForAll();
            return services;
        }

        private static IServiceCollection SameForAll(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                        .AddEntityFrameworkStores<IdentityContext>();

            return services;
        }
    }
}
