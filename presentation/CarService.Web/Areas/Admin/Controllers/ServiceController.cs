using AutoMapper;
using CarService.App.Interfaces;
using CarService.App.Models;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CarService.Web.Controllers.AdminArea
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;

        public ServiceController(IServiceManager serviceManager, IVehicleService vehicleService, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var paginatedServiceModel = await _serviceManager.GetPaginatetServicesAsync(page);
            var paginatedServiceViewModel = _mapper.Map<PaginationServiceViewModel>(paginatedServiceModel);
            return View(paginatedServiceViewModel);
        }

        [HttpPost]
        public IActionResult CreateBaseCostPartial(int id)
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommonEditServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.CreateServiceAsync(_mapper.Map<CommonEditServiceModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult GetCostTypesPartial(ServiceTypeViewModel id)
        {
            switch (id)
            {
                case ServiceTypeViewModel.EngineService:
                    ViewBag.CostTypes = typeof(EngineCostsTypesVM);
                    break;
                case ServiceTypeViewModel.TransmissionService:
                    ViewBag.CostTypes = typeof(TransmissionCostsTypesVM);
                    break;
                default:
                    return Content("");
            }
            return PartialView("ChoseTypeCostsPartial");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult GetCostPartial(CommonCostsTypesVM id) 
        {
            switch (id)
            {
                case CommonCostsTypesVM.CostByDriveUnit:
                    return PartialView("CreateCostByDriveUnitPartial");
                case CommonCostsTypesVM.CostByOneCylinder:
                    return PartialView("CreateCostByOneCylinderPartial");
                default:
                    return PartialView("CreateBaseCostPartial");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetParameterPartial(ParameterTypeViewModel id)
        {
            switch (id)
            {
                case ParameterTypeViewModel.DieselEngine:
                    return PartialView("CreateDieselEngineParameterPartial");
                case ParameterTypeViewModel.ElectricEngine:
                    return PartialView("CreateElectricEngineParameterPartial");
                case ParameterTypeViewModel.EngineName:
                    ViewBag.EngiesNames = new SelectList(await _vehicleService.GetAllEnginesAsync(), "NameEngine", "NameEngine",null, "EngineType");
                    return PartialView("CreateEngineNameParameterPartial");
                case ParameterTypeViewModel.ICEngine:
                    return PartialView("CreateICEngineParameterPartial");
                case ParameterTypeViewModel.PetrolEngine:
                    return PartialView("CreatePetrolEngineParameterPartial");
                default:
                    return Content("");
            }
        }
        

        [HttpGet]
        public async Task<IActionResult> Edit(string serviceId)
        {
            ViewBag.serviceId = serviceId;

            var model = await _serviceManager.GetServiceByIdAsync(serviceId);
            var viewModel = _mapper.Map<EditServiceViewModel>(model);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditServiceViewModel viewModel, string serviceId)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.EditServiceAsync(serviceId, _mapper.Map<EditServiceModel>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string serviceId)
        {
            await _serviceManager.RemoveServiceAsync(serviceId);
            return RedirectToAction("Index");
        }
    }
}
