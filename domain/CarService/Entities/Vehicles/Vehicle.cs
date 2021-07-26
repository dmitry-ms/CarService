using CarService.Entities.Base;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;

namespace CarService.Entities.Vehicles
{
    public class Vehicle : Entity
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public virtual Engine Engine { get; set; } 
        public virtual Transmission Transmission { get; set; } 
        public bool AirConditioning { get; set; }    //todo: Add different configurations    
    }
}
