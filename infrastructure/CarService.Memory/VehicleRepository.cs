using System;
using System.Linq;

namespace CarService.Memory
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Vehicle[] vehicles = new[]
        {
            new Vehicle(new Guid("24696077-A941-48D7-A707-7925A9E10529"), "VW", "Passat", "Diesel", "Robotic", true),
            new Vehicle(new Guid("711E8BE9-9E74-48E9-A46E-C88554F1EE87"), "Audi", "A4", "Diesel", "Manual", true),
            new Vehicle(new Guid("2424EFF4-BA44-4FEA-A463-98F51644CEBF"), "Ford", "Focus", "Petrol", "Automatic", false)
        };

        public Vehicle[] GetAllByBrandName(string brandName)
        {
            return vehicles.Where(vehicle => vehicle.BrandName.Contains(brandName)).ToArray();
        }
    }
}
