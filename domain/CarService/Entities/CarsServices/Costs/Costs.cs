using CarService.Entities.Vehicles;
using System;

namespace CarService.Entities.CarsServices.Costs
{
    public class Costs : BaseCosts
    {
        public decimal Price { get; set; }
        public TimeSpan Time { get; set; }

        public override decimal GetPrice(ClientCar car)
        {
            return Price;
        }

        public override TimeSpan GetRequiredTime(ClientCar car)
        {
            return Time;
        }
    }
}
