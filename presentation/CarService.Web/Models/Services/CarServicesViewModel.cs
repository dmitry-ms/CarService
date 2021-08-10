using System;

namespace CarService.Web.Models
{
    public class CarServicesViewModel
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan RequiredTime { get; set; }
        public ServiceTypeViewModel ServiceType { get; set; }
    }
}
