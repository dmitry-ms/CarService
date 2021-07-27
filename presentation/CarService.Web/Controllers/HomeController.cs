using AutoMapper;
using CarService.App.Interfaces;
using CarService.Data.EF.Identity;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly UserManager<CarServiceUser> _userManager;
        private readonly IClientCarService _clientCarService;
        private readonly IMapper _mapper;

        public HomeController(UserManager<CarServiceUser> userManager, 
            IClientCarService clientCarService,
            IMapper mapper)
        {
            _userManager = userManager;
            _clientCarService = clientCarService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {           
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Garage", "Home");  
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Garage()
        {
            var user = await _userManager.GetUserAsync(User);
            var carsModels = await _clientCarService.GetAllClientCars(new Guid(user.Id));
            var carsVM = _mapper.Map<IEnumerable<ClientCarVM>>(carsModels);
            return View(carsVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
