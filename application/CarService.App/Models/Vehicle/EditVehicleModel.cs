using System;

namespace CarService.App.Models
{
    public class EditVehicleModel
    {
        //public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string EngineId { get; set; } 
        public string TransmissionId { get; set; } 
        public bool AirConditioning { get; set; } 
    }
}
