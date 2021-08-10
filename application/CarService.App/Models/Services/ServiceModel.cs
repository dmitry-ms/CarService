using Domain.Enums;
using System;

namespace CarService.App.Models
{
    public class ServiceModel
    {
        public Guid Id { get; set; }        
        public ServiceType ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }

        //public BaseCosts Costs { get; set; }
        //public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
