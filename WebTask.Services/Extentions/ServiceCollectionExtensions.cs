using Microsoft.Extensions.DependencyInjection;
using WebTask.Services.Implementations;
using WebTask.Services.Interfaces;

namespace WebTask.Services.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            //return services;
        }
    }
}
