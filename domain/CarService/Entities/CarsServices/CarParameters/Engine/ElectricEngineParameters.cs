using CarService.Entities.Vehicles;
using CarService.Interfaces;

namespace CarService.Entities.CarsServices.CarParameters.Engine
{
    public class ElectricEngineParameters : EngineParameters
    {
        public int? MaxBatteryCapacity { get; set; }
        public int? MinBatteryCapacity { get; set; }

        public override bool IsAvailableFor(ClientCar car)
        {
            bool result = base.IsAvailableFor(car);

            if (result && car.Vehicle.Engine is IElectricEngine)
            {
                var electricEngine = car.Vehicle.Engine as IElectricEngine;
                result = (MaxBatteryCapacity == null ? true : electricEngine.BatteryCapacity <= MaxBatteryCapacity)
                    && (MinBatteryCapacity == null ? true : electricEngine.BatteryCapacity >= MinBatteryCapacity);
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
