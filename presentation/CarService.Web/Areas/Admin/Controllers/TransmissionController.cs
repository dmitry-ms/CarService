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
    public class TransmissionController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public TransmissionController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transmissions = await _vehicleService.GetAllTransmissionsAsync();
            return View(_mapper.Map<IEnumerable<TransmissionInfoVM>>(transmissions));
        }

        [HttpGet]
        public IActionResult CreateAutomaticTransmission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutomaticTransmission(CreateAutomaticTransmissionVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateTransmissionAsync(_mapper.Map<AutomaticTransmissionModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateMechanicTransmission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMechanicTransmission(CreateMechanicTransmissionVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateTransmissionAsync(_mapper.Map<MechanicTransmissionModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRoboticTransmission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoboticTransmission(CreateRoboticTransmissionVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateTransmissionAsync(_mapper.Map<RoboticTransmissionModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateVariatorTransmission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVariatorTransmission(CreateVariatorTransmissionVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateTransmissionAsync(_mapper.Map<VariatorTransmissionModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
