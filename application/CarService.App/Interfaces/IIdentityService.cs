using CarService.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IIdentityService
    {
        Task<(IdentityResult Result, string UserId)> CreateUserAsync(string userName, string password, string role, Person person);
        public Task AddUserToRoleAsync(Guid userId, string role);


        //Task<string> GetUserNameAsync(string userId);

        //Task<bool> IsInRoleAsync(string userId, string role);

        //Task<bool> AuthorizeAsync(string userId, string policyName);        

        //Task<IdentityResult> DeleteUserAsync(string userId);




        //public Task SignInAsync(Guid userId, bool isPersistent);
        //public Task SignOutAsync();
    }
}
