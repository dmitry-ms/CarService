using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult CreateTransmission(TransmissionTypeVM transmissionType, string returnController = null, string returnAction = null)
        {
            ViewBag.returnController = returnController;
            ViewBag.returnAction = returnAction;
            switch (transmissionType)
            {
                case TransmissionTypeVM.Automatic:
                    return View("CreateAutomaticTransmission");
                case TransmissionTypeVM.Mechanic:
                    return View("CreateMechanicTransmission");
                case TransmissionTypeVM.Robotic:
                    return View("CreateRoboticTransmission");
                case TransmissionTypeVM.Variator:
                    return View("CreateVariatorTransmission");
                default:
                    return View(new ErrorViewModel());          //todo: Создать свою ErrorView
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string transmissionId)
        {
            ViewBag.transmissionId = transmissionId;
            var model = await _vehicleService.GetTransmissionByIdAsync(new Guid(transmissionId));
            switch (model)
            {
                case AutomaticTransmissionModel:
                    return View("EditAutomaticTransmission", _mapper.Map<EditAutomaticTransmissionVM>(model));
                case MechanicTransmissionModel:
                    return View("EditMechanicTransmission", _mapper.Map<EditMechanicTransmissionVM>(model));
                case RoboticTransmissionModel:
                    return View("EditRoboticTransmission", _mapper.Map<EditRoboticTransmissionVM>(model));
                case VariatorTransmissionModel:
                    return View("EditVariatorTransmission", _mapper.Map<EditVariatorTransmissionVM>(model));
                default: return View(new ErrorViewModel());                 //todo: Создать свою ErrorView
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string transmissionId)
        {
            await _vehicleService.RemoveTransmissionAsync(new Guid(transmissionId));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAutomaticTransmission(AutomaticTransmissionVM model, string returnController = null,
            string returnAction = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateTransmissionAsync(_mapper.Map<AutomaticTransmissionModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new{transmissionId = result.Id});
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMechanicTransmission(MechanicTransmissionVM model, string returnController = null,
            string returnAction = null, string transmissionId = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateTransmissionAsync(_mapper.Map<MechanicTransmissionModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new { transmissionId = result.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRoboticTransmission(RoboticTransmissionVM model, string returnController = null,
            string returnAction = null, string transmissionId = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateTransmissionAsync(_mapper.Map<RoboticTransmissionModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new { transmissionId = result.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVariatorTransmission(VariatorTransmissionVM model, string returnController = null,
            string returnAction = null, string transmissionId = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.CreateTransmissionAsync(_mapper.Map<VariatorTransmissionModel>(model));
                return returnController == null || returnAction == null ? RedirectToAction("Index")
                    : RedirectToAction(returnAction, returnController, new { transmissionId = result.Id });
            }
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAutomaticTransmission(AutomaticTransmissionVM viewModel, string transmissionId)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditTransmissionAsync(new Guid(transmissionId), _mapper.Map<AutomaticTransmissionModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMechanicTransmission(MechanicTransmissionVM  viewModel, string transmissionId)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditTransmissionAsync(new Guid(transmissionId), _mapper.Map<MechanicTransmissionModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRoboticTransmission(RoboticTransmissionVM viewModel, string transmissionId)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditTransmissionAsync(new Guid(transmissionId), _mapper.Map<RoboticTransmissionModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVariatorTransmission(VariatorTransmissionVM viewModel, string transmissionId)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.EditTransmissionAsync(new Guid(transmissionId), _mapper.Map<VariatorTransmissionModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel); ;
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckNameTransmission(string name, string oldName)
        {
            if (name != oldName)
            {
                var transmissions = await _vehicleService.GetAllTransmissionsAsync();
                if (transmissions.Any(e => e.Name.ToLower() == name.ToLower()))
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
