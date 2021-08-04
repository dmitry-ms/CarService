using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Data.EF.Identity;
using CarService.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarService.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<CarServiceUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(SignInManager<CarServiceUser> signInManager,
            IMapper mapper,
            IAccountService accountService)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationClientVM model)
        {
            if (ModelState.IsValid)
            {
                await _accountService.RegisterClientAsync(_mapper.Map<RegistrationClientModel>(model));
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    else                   
                        return RedirectToAction("Index", "Home");                   
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");  
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
