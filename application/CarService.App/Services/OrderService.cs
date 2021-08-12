using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var ordersModel = new List<OrderModel>();
            var orders = await _orderRepository.GetAllAsync();
            if (orders.Any())
            {
                foreach (var item in orders)
                {
                    var order = new OrderModel
                    {
                        Id = item.Id,
                        DateAdded = item.DateAdded.ToLocalTime(),
                        Car = ObjectMapper.Mapper.Map<ClientCarModel>(item.Car),
                        Services = ObjectMapper.Mapper.Map<IEnumerable<ServiceInfoModel>>(item.Services)
                    };
                    ordersModel.Add(order);
                }
                return ordersModel;
            }
            return Array.Empty<OrderModel>();
        }
    }
}
