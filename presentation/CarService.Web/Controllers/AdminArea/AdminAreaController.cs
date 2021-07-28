using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Web.Controllers.AdminArea
{
    //[Area("Admin")] //TODO: Figure out areas
    [Authorize(Roles = "Admin")]              
    public class AdminAreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
