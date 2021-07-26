using CarService.Entities.Vehicles;

namespace CarService.Interfaces
{
    public interface IParameters
    {
        public bool IsAvailableFor(ClientCar car);
    }
}
