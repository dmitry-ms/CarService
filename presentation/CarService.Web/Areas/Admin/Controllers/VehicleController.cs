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
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return View(_mapper.Map<IEnumerable<VehicleInfoVM>>(vehicles));
        }

        [HttpGet]
        public async Task<IActionResult> Create(string engineId = null, string transmissionId = null)
        {
            var engines = _mapper.Map<IEnumerable<EngineInfoVM>>(await _vehicleService.GetAllEnginesAsync());
            ViewBag.Engines = new SelectList(engines, "Id", "NameEngine", engineId, "EngineType");

            var transmissions = _mapper.Map<IEnumerable<TransmissionInfoVM>>(await _vehicleService.GetAllTransmissionsAsync());
            ViewBag.Transmissions = new SelectList(transmissions, "Id", "Name", transmissionId, "TransmissionType");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                //await _vehicleService.CreateVehicleAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
