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
using System;

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
        public async Task<IActionResult> Index(int page = 1)
        {
            //var vehicles = await _vehicleService.GetAllVehiclesAsync();
            //return View(_mapper.Map<IEnumerable<VehicleInfoVM>>(vehicles));            

            var paginatedVehiclesModel = await _vehicleService.GetPaginatetVehiclesAsync(page);
            var paginatedVehicleViewModel = _mapper.Map<PaginationVehicleViewModel>(paginatedVehiclesModel);
            return View(paginatedVehicleViewModel);
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
        public async Task<IActionResult> Create(EditVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateVehicleAsync(_mapper.Map<EditVehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string vehicleId)
        {
            ViewBag.vehicleId = vehicleId;
            var model = await _vehicleService.GetVehicleByIdAsync(new Guid(vehicleId));
            var viewModel = _mapper.Map<EditVehicleVM>(model);  //заменить VM

            var engines = _mapper.Map<IEnumerable<EngineInfoVM>>(await _vehicleService.GetAllEnginesAsync());
            ViewBag.Engines = new SelectList(engines, "Id", "NameEngine", viewModel.EngineId, "EngineType");

            var transmissions = _mapper.Map<IEnumerable<TransmissionInfoVM>>(await _vehicleService.GetAllTransmissionsAsync());
            ViewBag.Transmissions = new SelectList(transmissions, "Id", "Name", viewModel.TransmissionId, "TransmissionType");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVehicleVM viewModel, string vehicleId)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditVehicleAsync(new Guid(vehicleId), _mapper.Map<EditVehicleModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Remove(string vehicleId)
        {
            await _vehicleService.RemoveVehicleAsync(new Guid(vehicleId));
            return RedirectToAction("Index");
        }
    }
}
