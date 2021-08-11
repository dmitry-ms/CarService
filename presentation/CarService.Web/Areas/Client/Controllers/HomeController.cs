using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarService.Web.Areas.User.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]
    public class HomeController : Controller
    {
        private readonly IClientCarService _clientCarService;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public HomeController(IClientCarService clientCarService, IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _clientCarService = clientCarService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carsModels = await _clientCarService.GetAllClientCars(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var carsVM = _mapper.Map<IEnumerable<ClientCarVM>>(carsModels);
            return View(carsVM);
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            ViewBag.brandNames = new SelectList(await _vehicleService.GetBrandNamesAsync());            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddClientCarVM viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _clientCarService.AddClientCarAsync(_mapper.Map<AddClientCarModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetModels(string brand)
        {
             var modelsNames = await _vehicleService.GetModelNamesAsync(brand);

            return Json(modelsNames);
        }

        [HttpPost]
        public async Task<IActionResult> GetEngines(string brand, string model)
        {
            var enginesNames = await _vehicleService.GetEnginesNamesAsync(brand, model);
           
            return Json(enginesNames);
        }
    }
}
