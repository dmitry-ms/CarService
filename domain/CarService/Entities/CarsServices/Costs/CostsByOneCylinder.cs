using CarService.Entities.Vehicles;
using CarService.Interfaces;
using System;

namespace CarService.Entities.CarsServices.Costs
{
    public class CostsByOneCylinder : BaseCosts
    {
        public decimal PriceByOneCylinder { get; set; }
        public TimeSpan TimeByOneCylinder { get; set; }

        public override decimal GetPrice(ClientCar car)
        {
            return PriceByOneCylinder * GetNumberCylinders(car);
        }
        public override TimeSpan GetRequiredTime(ClientCar car)
        {
            return TimeByOneCylinder.Multiply(GetNumberCylinders(car));
        }
        public override bool IsAvailableFor(ClientCar car)
        {
            return (car.Vehicle.Engine is IICEngine && base.IsAvailableFor(car));
        }
        private int GetNumberCylinders(ClientCar car)
        {
            return (car.Vehicle.Engine as IICEngine).NumberCylinders;
        }
    }
}
