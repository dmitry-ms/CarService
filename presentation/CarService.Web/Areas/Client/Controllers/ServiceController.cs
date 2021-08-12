using AutoMapper;
using CarService.App.Interfaces;
using CarService.Web.Extentions;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _autoMapper;

        public ServiceController(IServiceManager serviceManager, IMapper autoMapper)
        {
            _serviceManager = serviceManager;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailableServicesForCar(Guid carId)
        {
            ViewBag.amount = HttpContext.Session.GetBasketCount(carId);
            ViewBag.basketItems = HttpContext.Session.GetBasketItems(carId);
            ViewBag.carId = carId;

            var carServices = _autoMapper.Map<IEnumerable<CarServicesViewModel>>(
                await _serviceManager.GetAllServicesForCarAsync(carId.ToString()));

            return View(carServices);
        }

        [HttpGet]
        public async Task<IActionResult> SubmitOrder(Guid carId)
        {
            await _serviceManager.AddOrderAsync(carId, HttpContext.Session.Get<IEnumerable<Guid>>(carId.ToString()));
            HttpContext.Session.CleanBasket(carId);
            return RedirectToAction("Index","Home",null);
        }

        [HttpPost]
        public async Task<IActionResult> Basket(Guid carId)
        {
            var basketItems = _autoMapper.Map<ServiceBasketViewModel>(
                await _serviceManager.GetTotalCostsAsync(HttpContext.Session.GetBasketItems(carId), carId));

            return PartialView("BasketPartial",basketItems);
        }

        [HttpPost]
        public IActionResult AddServiceToBasket(Guid serviceId, Guid carId)
        {
            int amount = HttpContext.Session.AddToBasket(serviceId, carId);
            return Json(new { serviceId = serviceId, amount = amount });
        }

        [HttpPost]
        public IActionResult RemoveServiceFromBasket(Guid serviceId, Guid carId)
        {
            int amount = HttpContext.Session.RemoveFromBasket(serviceId, carId);
            return Json(new { serviceId = serviceId, amount = amount });
        }
    }
}
