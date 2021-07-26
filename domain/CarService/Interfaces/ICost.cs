using CarService.Entities.Vehicles;
using System;

namespace CarService.Interfaces
{
    public interface ICost
    {
        decimal GetPrice(ClientCar car);

        TimeSpan GetRequiredTime(ClientCar car);

        bool IsAvailableFor(ClientCar car);
    }
}
