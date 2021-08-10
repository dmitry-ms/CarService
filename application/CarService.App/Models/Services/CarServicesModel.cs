using Domain.Enums;
using System;

namespace CarService.App.Models
{
    public class CarServicesModel
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan RequiredTime { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
