using CarService.Entities.Vehicles;
using CarService.Interfaces;

namespace CarService.Entities.CarsServices.CarParameters.Engine
{
    public class DieselEngineParameters : ICEngineParameters
    {
        public bool? DEF { get; set; }

        public override bool IsAvailableFor(ClientCar car)
        {
            bool result = base.IsAvailableFor(car);

            if (result && car.Vehicle.Engine is IDieselEngine)
            {
                var dieselEngine = car.Vehicle.Engine as IDieselEngine;
                result = DEF == null ? true : dieselEngine.DEF == DEF;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
