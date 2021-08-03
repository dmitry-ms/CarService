using CarService.App.Constants;
using CarService.Data.EF.Identity;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;
using CarService.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Data.EF.Data
{
    public static class CarServiceDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<CarServiceUser> userManager,
            RoleManager<CarServiceRole> roleManager)
        {
            var adminRole = new CarServiceRole { Id = Guid.NewGuid().ToString(), Name = RoleNames.ADMIN };
            var clientRole = new CarServiceRole { Id = Guid.NewGuid().ToString(), Name = RoleNames.CLIENT };
            var serviceManRole = new CarServiceRole{ Id = Guid.NewGuid().ToString(), Name = RoleNames.SERVICEMAN};

            if (roleManager.Roles.All(r => r.Name != adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }
            if (roleManager.Roles.All(r => r.Name != clientRole.Name))
            {
                await roleManager.CreateAsync(clientRole);
            }
            if (roleManager.Roles.All(r => r.Name != serviceManRole.Name))
            {
                await roleManager.CreateAsync(serviceManRole);
            }

            var admin = new CarServiceUser {Id = Guid.NewGuid().ToString(), UserName = "admin", Email = "admin@localhost" };
            var client = new CarServiceUser { Id = Guid.NewGuid().ToString(), UserName = "client", Email = "client@localhost" };
            var serviceMan = new CarServiceUser { Id = Guid.NewGuid().ToString(), UserName = "serviceMan", Email = "serviceMan@localhost" };

            var users = userManager.Users;
            if (users.All(u => u.UserName != admin.UserName))
            {
                await userManager.CreateAsync(admin, "1qaz2wsX");
                await userManager.AddToRolesAsync(admin, new[] { adminRole.Name });
            }
            
            if (users.All(u => u.UserName != client.UserName))
            {
                await userManager.CreateAsync(client, "1qaz2wsX");
                await userManager.AddToRolesAsync(client, new[] { clientRole.Name });
            }
            
            if (users.All(u => u.UserName != serviceMan.UserName))
            {
                await userManager.CreateAsync(serviceMan, "1qaz2wsX");
                await userManager.AddToRolesAsync(serviceMan, new[] { serviceManRole.Name });
            }            
        }

        public static async Task SeedSampleDataAsync(IVehicleRepository vehicleRepository)
        {
            var vehicles = await vehicleRepository.GetAllAsync();
            if (vehicles != null && vehicles.Count < 1)
            {
                var engine1 = new DieselEngine { Id = Guid.NewGuid(), NameEngine = "JZ23", NumberCylinders = 6, NumberValves = 16, EnginePowerKW = 120, EngineVolumeSquareCentimeter = 2500, DEF = true };
                var engine2 = new DieselEngine { Id = Guid.NewGuid(), NameEngine = "DN43", NumberCylinders = 5, NumberValves = 10, EnginePowerKW = 75, EngineVolumeSquareCentimeter = 1900, DEF = false };
                var transmission1 = new RoboticTransmission { Id = Guid.NewGuid(), Name = "DQ300", NumberOfGears = 7, DriveUnit = Enums.DriveUnit.FourWheelDrive };
                var transmission2 = new RoboticTransmission { Id = Guid.NewGuid(), Name = "DQ250", NumberOfGears = 6, DriveUnit = Enums.DriveUnit.FrontWheelDrive };

                await vehicleRepository.AddAsync(new Vehicle { Id = Guid.NewGuid(), AirConditioning = true, BrandName = "VW", ModelName = "Toureg", Engine = engine1, Transmission = transmission1 });
                await vehicleRepository.AddAsync(new Vehicle { Id = Guid.NewGuid(), AirConditioning = true, BrandName = "Audi", ModelName = "Q7", Engine = engine2, Transmission = transmission2 });
                await vehicleRepository.SaveChangesAsync();
            }
        }
    }
}
