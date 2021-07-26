using CarService.Entities.Base;
using CarService.Entities.Users;
using System;

namespace CarService.Entities.Vehicles
{
    public class ClientCar : Entity
    {
        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
        public DateTime YearProduction { get; set; }
        public int MileageKM { get; set; }
        public string VinNumber { get; set; }
        public string CarPlate { get; set; }
        public string Color { get; set; }
    }
}
