using System;
using System.Collections.Generic;

namespace CarService.App.Models
{
    public class ServiceBasketModel
    {
        public IEnumerable<CarServicesModel> Services { get; set; } = new List<CarServicesModel>();

        public TimeSpan TotalTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
