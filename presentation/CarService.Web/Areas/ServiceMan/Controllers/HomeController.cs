using AutoMapper;
using CarService.App.Interfaces;
using CarService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Web.Areas.ServiceMan.Controllers
{
    [Area("ServiceMan")]
    [Authorize(Roles = "ServiceMan")]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public HomeController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = _mapper.Map<IEnumerable<OrderViewModel>>(await _orderService.GetAllOrdersAsync());
            return View(orders);
        }
    }
}
