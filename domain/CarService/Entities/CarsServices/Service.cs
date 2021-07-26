using CarService.Entities.CarsServices.Costs;
using CarService.Entities.Orders;
using Domain.Enums;
using System.Collections.Generic;

namespace CarService.Entities.CarsServices
{
    public class Service
    {
        public virtual BaseCosts Costs { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public virtual IList<Order> Orders { get; set; } = new List<Order>();
    }
}
