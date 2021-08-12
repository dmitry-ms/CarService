using CarService.App.Interfaces;
using CarService.Data.EF.Data;
using CarService.Data.EF.Identity;
using CarService.Data.EF.Repository;
using CarService.Data.EF.Repository.Base;
using CarService.Repositories;
using CarService.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.Data.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarServiceDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CarServiceDbContext).Assembly.FullName)));

            //services.AddDefaultIdentity<CarServiceUser>()   //using "DefaultIdentity" adds: 1)AddIdentity 2)AddDefaultUI 3)AddDefaultTokenProviders
            //    .AddRoles<CarServiceRole>()
            //    .AddEntityFrameworkStores<CarServiceDbContext>();

            services.AddIdentity<CarServiceUser, CarServiceRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequireLowercase = false; 
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<CarServiceDbContext>()
                .AddDefaultTokenProviders();                      

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IClientCarRepository, ClientCarRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<IServiceManRepository, ServiceManRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();


            return services;
        }
    }
}
