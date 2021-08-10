using CarService.Entities.Base;
using CarService.Entities.CarsServices.Costs;
using CarService.Entities.Orders;
using CarService.Entities.Vehicles;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace CarService.Entities.CarsServices
{
    public class Service : Entity
    {
        public virtual BaseCosts Costs { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public virtual IList<Order> Orders { get; set; } = new List<Order>();

        public bool IsAvailableFor(ClientCar car)
        {
            return Costs.IsAvailableFor(car);
        }
        public decimal GetPrice(ClientCar car)
        {
            return Costs.GetPrice(car);
        }
        public TimeSpan GetRequiredTime(ClientCar car)
        {
            return Costs.GetRequiredTime(car);
        }
    }
}
