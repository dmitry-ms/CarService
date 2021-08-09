using CarService.App.Models.Base;
using System;

namespace CarService.App.Models
{
    public class CostsByDriveUnitModel
    {
        public Guid Id { get; set; }

        public decimal PriceByFourWheelDrive { get; set; }
        public decimal PriceByFrontWheelDriveOrMono { get; set; }
        public decimal? PriceByRearWheelDrive { get; set; }

        public TimeSpan TimeByFourWheelDrive { get; set; }
        public TimeSpan TimeByFrontWheelDriveOrMono { get; set; }
        public TimeSpan? TimeByRearWheelDrive { get; set; }
    }
}
