using CarService.Entities.Base;
using CarService.Entities.CarsServices.CarParameters;
using CarService.Entities.Vehicles;
using System;

namespace CarService.Entities.CarsServices.Costs
{
    public abstract class BaseCosts : Entity
    {
        public virtual Parameters CarParameters { get; set; }

        public abstract decimal GetPrice(ClientCar car);
        public abstract TimeSpan GetRequiredTime(ClientCar car);

        public virtual bool IsAvailableFor(ClientCar car)
        {
            var result = true;

            if (CarParameters != null)
            {
                result = CarParameters.IsAvailableFor(car);
            }
            return result;
        }
    }
}
