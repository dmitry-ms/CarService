using System;

namespace CarService.App.Models
{
    public class CostsByOneCylinderModel
    {
        public Guid Id { get; set; }
        public decimal PriceByOneCylinder { get; set; }
        public TimeSpan TimeByOneCylinder { get; set; }
    }
}
