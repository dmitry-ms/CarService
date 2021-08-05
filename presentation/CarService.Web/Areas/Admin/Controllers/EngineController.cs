using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var engines = await _vehicleService.GetAllEnginesAsync();
            return View(_mapper.Map<IEnumerable<EngineInfoVM>>(engines));
        }

        [HttpGet]
        public IActionResult CreateEngine(EngineTypeVM engineType, string returnController = null, string returnAction = null)
        {
            ViewBag.returnController = returnController;
            ViewBag.returnAction = returnAction;
            switch (engineType)
            {
                case EngineTypeVM.DieselEngine:
                    return View("CreateDieselEngine");
                case EngineTypeVM.PetrolEngine:
                    return View("CreatePetrolEngine");
                case EngineTypeVM.ElectricEngine:
                    return View("CreateElectricEngine");
                default:
                    return View(new ErrorViewModel());               //todo: Создать свою ErrorView
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDieselEngine(DieselEngineVM model, string returnController = null,
            string returnAction = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateEngineAsync(_mapper.Map<DieselEngineModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new{ engineId = result.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePetrolEngine(PetrolEngineVM model, string returnController = null,
            string returnAction = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateEngineAsync(_mapper.Map<PetrolEngineModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new { engineId = result.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateElectricEngine(ElectricEngineVM model, string returnController = null,
            string returnAction = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateEngineAsync(_mapper.Map<ElectricEngineModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new { engineId = result.Id });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string engineId)
        {
            ViewBag.engineId = engineId;
            var model = await _vehicleService.GetEngineByIdAsync(new Guid(engineId));
            switch (model)
            {
                case DieselEngineModel:
                    return View("EditDieselEngine", _mapper.Map<EditDieselEngineVM>(model));
                case PetrolEngineModel:
                    return View("EditPetrolEngine", _mapper.Map<EditPetrolEngineVM>(model));
                case ElectricEngineModel:
                    return View("EditElectricEngine", _mapper.Map<EditElectricEngineVM>(model));
                default: return View(new ErrorViewModel());                 //todo: Создать свою ErrorView
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDieselEngine(DieselEngineVM viewModel, string engineId = null)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditEngineAsync(new Guid(engineId), _mapper.Map<DieselEngineModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPetrolEngine(PetrolEngineVM viewModel,  string engineId = null)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditEngineAsync(new Guid(engineId), _mapper.Map<PetrolEngineModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditElectricEngine(ElectricEngineVM viewModel, string engineId = null)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditEngineAsync(new Guid(engineId), _mapper.Map<ElectricEngineModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string engineId)
        {
            await _vehicleService.RemoveEngineAsync(new Guid(engineId));
            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckNameEngine(string nameEngine, string oldName)
        {
            if (nameEngine != oldName)
            {
                var engines = await _vehicleService.GetAllEnginesAsync();
                if (engines.Any(e => e.NameEngine.ToLower() == nameEngine.ToLower()))
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
