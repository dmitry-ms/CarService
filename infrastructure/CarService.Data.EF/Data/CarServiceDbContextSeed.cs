using CarService.App.Constants;
using CarService.Data.EF.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Data.EF.Data
{
    public static class CarServiceDbContextSeed
    {
        private const string _adminRoleId = "8DF96E91-78E9-40B6-BB1A-AC8965D7208B";
        private const string _clientRoleId = "F29263FB-893D-42B3-8DE4-A849F091E296";
        private const string _serviceManRoleId = "8C022645-D365-4A46-A148-FBF0DB4E8B71";

        public static async Task SeedDefaultUserAsync(UserManager<CarServiceUser> userManager,
            RoleManager<CarServiceRole> roleManager)
        {
            var adminRole = new CarServiceRole { Id = _adminRoleId, Name = RoleNames.ADMIN };
            var clientRole = new CarServiceRole { Id = _clientRoleId, Name = RoleNames.CLIENT };
            var serviceManRole = new CarServiceRole{ Id = _serviceManRoleId, Name = RoleNames.SERVICEMAN};

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
                await userManager.CreateAsync(admin, "admin");
                await userManager.AddToRolesAsync(admin, new[] { adminRole.Name });
            }
            
            if (users.All(u => u.UserName != client.UserName))
            {
                await userManager.CreateAsync(client, "client");
                await userManager.AddToRolesAsync(client, new[] { clientRole.Name });
            }
            
            if (users.All(u => u.UserName != serviceMan.UserName))
            {
                await userManager.CreateAsync(serviceMan, "serviceMan");
                await userManager.AddToRolesAsync(serviceMan, new[] { serviceManRole.Name });
            }
        }
    }
}
