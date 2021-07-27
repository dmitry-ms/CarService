using CarService.Entities.Base;
using CarService.Entities.Vehicles;
using CarService.Interfaces;

namespace CarService.Entities.CarsServices.CarParameters
{
    public abstract class Parameters : Entity, IParameters
    {
        public abstract bool IsAvailableFor(ClientCar car);
    }
}
