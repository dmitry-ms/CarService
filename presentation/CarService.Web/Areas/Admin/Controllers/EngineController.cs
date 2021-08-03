using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EngineController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public EngineController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var engines = await _vehicleService.GetAllEngines();
            return View(_mapper.Map<IEnumerable<EngineInfoVM>>(engines));
        }

        [HttpGet]
        public IActionResult CreateDieselEngine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDieselEngine(CreateDieselEngineVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateEngineAsync(_mapper.Map<DieselEngineModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePetrolEngine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetrolEngine(CreatePetrolEngineVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateEngineAsync(_mapper.Map<PetrolEngineModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateElectricEngine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateElectricEngine(CreateElectricEngineVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateEngineAsync(_mapper.Map<ElectricEngineModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
