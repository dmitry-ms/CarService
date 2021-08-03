using AutoMapper;
using CarService.Data.EF.Identity;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Web.Controllers.AdminArea
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<CarServiceRole> _roleManager;
        private readonly UserManager<CarServiceUser> _userManager;
        private readonly IMapper _mapper;
              
        public UsersController(RoleManager<CarServiceRole> roleManager, UserManager<CarServiceUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<UserVM>>(_userManager.Users.ToList()));            
        }

        public async Task<IActionResult> Edit(string userId)
        {
            CarServiceUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleVM model = new ChangeRoleVM
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            CarServiceUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index");
            }

            return NotFound();
        }

















        //public IActionResult RolesList()
        //{
        //    return View(_roleManager.Roles.ToList());
        //}
        //public IActionResult Create() => View();
        //[HttpPost]
        //public async Task<IActionResult> Create(string name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(name);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        IdentityResult result = await _roleManager.DeleteAsync(role);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
