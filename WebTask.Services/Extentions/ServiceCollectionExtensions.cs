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

namespace WebTask.Services
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
