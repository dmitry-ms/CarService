using System;

namespace CarService.App.Models
{
    public class VehicleInfoModel
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public EngineInfoModel Engine { get; set; }
        public TransmissionInfoModel Transmission { get; set; }
        public bool AirConditioning { get; set; }    
    }
}
