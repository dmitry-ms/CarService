using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CarService.Web.Controllers.AdminArea
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            return View(_mapper.Map<IEnumerable<VehicleInfoVM>>(vehicles));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var engines = await _vehicleService.GetAllEngines();
            ViewBag.Engines = new SelectList(engines, "Id", "NameEngine",null,"EngineType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                //await _vehicleService.CreateEngineAsync(_mapper.Map<DieselEngineModel>(model));
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        //[HttpGet]
        //public IActionResult CreatePetrolEngine()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreatePetrolEngine(CreatePetrolEngineVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _vehicleService.CreateEngineAsync(_mapper.Map<PetrolEngineModel>(model));
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult CreateElectricEngine()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public  async Task<IActionResult> CreateElectricEngine(CreateElectricEngineVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _vehicleService.CreateEngineAsync(_mapper.Map<ElectricEngineModel>(model));
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}
