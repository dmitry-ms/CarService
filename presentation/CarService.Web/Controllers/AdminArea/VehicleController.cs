using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Web.Controllers.AdminArea
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
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
        public IActionResult CreateDieselEngine(CreateDieselEngineVM model)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.CreateEngine(_mapper.Map<DieselEngineModel>(model));
            }
            return View(model);
        }

        //public IActionResult RolesList()
        //{
        //    return View(_roleManager.Roles.ToList());
        //}
    }
}
