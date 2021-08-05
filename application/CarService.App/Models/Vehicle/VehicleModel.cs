using System;

namespace CarService.App.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public EngineModel Engine { get; set; } 
        public TransmissionModel Transmission { get; set; } 
        public bool AirConditioning { get; set; } 
    }
}
