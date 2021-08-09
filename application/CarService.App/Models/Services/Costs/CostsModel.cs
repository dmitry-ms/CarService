using CarService.App.Models.Base;
using System;

namespace CarService.App.Models
{
    public class CostsModel
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }
        public TimeSpan Time { get; set; }
    }
}
