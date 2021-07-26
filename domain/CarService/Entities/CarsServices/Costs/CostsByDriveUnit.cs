using CarService.Entities.Vehicles;
using CarService.Enums;
using System;

namespace CarService.Entities.CarsServices.Costs
{
    public class CostsByDriveUnit : BaseCosts
    {
        public decimal PriceByFourWheelDrive { get; set; }
        public decimal PriceByFrontWheelDriveOrMono { get; set; }
        public decimal? PriceByRearWheelDrive { get; set; }

        public TimeSpan TimeByFourWheelDrive { get; set; }
        public TimeSpan TimeByFrontWheelDriveOrMono { get; set; }
        public TimeSpan? TimeByRearWheelDrive { get; set; }

        public override bool IsAvailableFor(ClientCar car)
        {
            return base.IsAvailableFor(car);
        }
        public override decimal GetPrice(ClientCar car)
        {
            var driveUnit = car.Vehicle.Transmission.DriveUnit;
            switch (driveUnit)
            {
                case DriveUnit.FourWheelDrive:
                    return PriceByFourWheelDrive;
                case DriveUnit.FrontWheelDrive:
                    return PriceByFrontWheelDriveOrMono;
                case DriveUnit.RearWheelDrive:
                    return PriceByRearWheelDrive ?? PriceByFrontWheelDriveOrMono;
            }
            throw new Exception("Привод автомобиля не указан.");
        }

        public override TimeSpan GetRequiredTime(ClientCar car)
        {
            var driveUnit = car.Vehicle.Transmission.DriveUnit;
            switch (driveUnit)
            {
                case DriveUnit.FourWheelDrive:
                    return TimeByFourWheelDrive;
                case DriveUnit.FrontWheelDrive:
                    return TimeByFrontWheelDriveOrMono;
                case DriveUnit.RearWheelDrive:
                    return TimeByRearWheelDrive ?? TimeByFrontWheelDriveOrMono;
            }
            throw new Exception("Привод автомобиля не указан.");
        }
    }
}
