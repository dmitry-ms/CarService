using CarService.App.Interfaces;
using CarService.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IClientCarService, ClientCarService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IServiceManager, ServiceManager>();

            return services;
        }
    }
}
