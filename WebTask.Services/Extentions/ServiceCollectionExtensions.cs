using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.Services.Implementations;
using WebTask.Services.Implementations.Identity;
using WebTask.Services.Implementations.Shop;
using WebTask.Services.Mapings.Shop;

namespace WebTask.Services
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            services.AddAutoMapper(typeof(TypeProfile).Assembly);
            services.AddAutoMapper(typeof(SizeProfile).Assembly);

            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<ISizeService, SizeService>();
            return services;
        }
    }
}
