using System;

namespace CarService.App.Models
{
    public class AddClientCarModel
    {
        public string VehicleId { get; set; }

        public string UserId { get; set; }

        public DateTime YearProduction { get; set; }

        public int? MileageKM { get; set; }

        public string VinNumber { get; set; }

        public string CarPlate { get; set; }

        public string Color { get; set; }
    }
}
