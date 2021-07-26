using CarService.Entities.Vehicles;
using CarService.Interfaces;

namespace CarService.Entities.CarsServices.CarParameters.Engine
{
    public class PetrolEngineParameters : ICEngineParameters
    {
        public override bool IsAvailableFor(ClientCar car)
        {
            bool result = base.IsAvailableFor(car);

            if (result && car.Vehicle.Engine is IPetrolEngine)
            {
                //
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
