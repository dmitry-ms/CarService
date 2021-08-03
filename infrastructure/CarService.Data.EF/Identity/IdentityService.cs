using CarService.App.Interfaces;
using CarService.Data.EF.Identity;
using CarService.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Data.EF.Identity
{
    public class IdentityService : IIdentityService
    {
        //todo: разобраться с этим сервисом!!!
        private readonly UserManager<CarServiceUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(UserManager<CarServiceUser> manager,
            IAuthorizationService authorizationService)
        {
            _userManager = manager;
            _authorizationService = authorizationService;
        }

        public async Task<(IdentityResult, string)> CreateUserAsync(string userName, string password, string role, Person person)
        {
            var user = new CarServiceUser
            {
                Id = Guid.NewGuid().ToString(),        
                Email = userName,
                UserName = userName,
                Person = person
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await AddUserToRoleAsync(user, role);
            };

            return (result, user.Id);                     
        }

        internal async Task AddUserToRoleAsync(CarServiceUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
        public async Task AddUserToRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            await AddUserToRoleAsync(user, role);
        }
        //internal async Task SignInAsync(CarServiceUser user, bool isPersistent)
        //{
        //    await _signInManager.SignInAsync(user, false);
        //}
        //public async Task SignInAsync(Guid userId, bool isPersistent)
        //{
        //    var user = await _userManager.FindByIdAsync(userId.ToString());
        //    await SignInAsync(user, isPersistent);
        //}
        //public async Task SignOutAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //}

        /////////////////////////////////////////////////////////////////////////////////


        public async Task<bool> CheckPasswordAsync(CarServiceUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<CarServiceUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetRolesAsync(CarServiceUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IList<CarServiceUser>> GetUsersInRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task UpdateAsync(CarServiceUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteAsync(CarServiceUser user)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}
