using AutoMapper;
using CarService.App.Interfaces;
using CarService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IServiceManager _servicesManage;
        private readonly IMapper _mapper;

        public HomeController(IServiceManager servicesManager, IMapper mapper)
        {
            _servicesManage = servicesManager;
            _mapper = mapper;
        }

        public ActionResult Index()
        {           
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                if (User.IsInRole("Client"))
                    return RedirectToAction("Index", "Home", new { area = "Client" });
                if (User.IsInRole("ServiceMan"))
                    return RedirectToAction("Index", "Home", new { area = "ServiceMan" });
            };  
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OurServices()
        {
            var services = _mapper.Map<IEnumerable<GroupedServicesVM>>(
                await _servicesManage.GetServicesGroupedByType());

            return View(services);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
