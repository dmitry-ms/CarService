using CarService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
