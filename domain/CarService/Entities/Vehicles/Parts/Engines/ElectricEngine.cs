using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Engines
{
    public class ElectricEngine : Engine, IElectricEngine
    {
        public int BatteryCapacity { get; set; }
    }
}
