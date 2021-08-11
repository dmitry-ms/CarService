using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ServiceBasketViewModel
    {
        public IEnumerable<CarServicesViewModel> Services { get; set; }

        public TimeSpan TotalTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
