using AutoMapper;
using CarService.App.Interfaces;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _autoMapper;

        public ServiceController(IServiceManager serviceManager, IMapper autoMapper)
        {
            _serviceManager = serviceManager;
            _autoMapper = autoMapper;
        }


        public async Task<IActionResult> GetAllAvailableServicesForCar(string carId = null)
        {
            var carServices = _autoMapper.Map<IEnumerable<CarServicesViewModel>>(
                await _serviceManager.GetAllServicesForCarAsync(carId));



            return View(carServices);
        }
    }
}
