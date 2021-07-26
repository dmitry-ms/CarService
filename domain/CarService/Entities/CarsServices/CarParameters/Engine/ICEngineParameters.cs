using CarService.Entities.Vehicles;
using CarService.Interfaces;

namespace CarService.Entities.CarsServices.CarParameters.Engine
{
    public class ICEngineParameters : EngineParameters
    {
        public int? MaxEngineVolume { get; set; }
        public int? MinEngineVolume { get; set; }
        public int? MaxNumberCylinders { get; set; }
        public int? MinNumberCylinders { get; set; }
        public int? MaxNumberValves { get; set; }
        public int? MinNumberValves { get; set; }

        public override bool IsAvailableFor(ClientCar car)
        {
            bool result = base.IsAvailableFor(car);

            if (result && car.Vehicle.Engine is IICEngine)
            {
                var icengine = car.Vehicle.Engine as IICEngine;

                result = (MaxEngineVolume == null ? true : icengine.EngineVolumeSquareCentimeter <= MaxEngineVolume)
                    && (MinEngineVolume == null ? true : icengine.EngineVolumeSquareCentimeter >= MinEngineVolume)
                    && (MaxNumberCylinders == null ? true : icengine.NumberCylinders <= MaxNumberCylinders)
                    && (MinNumberCylinders == null ? true : icengine.NumberCylinders >= MinNumberCylinders)
                    && (MaxNumberValves == null ? true : icengine.NumberValves <= MaxNumberValves)
                    && (MinNumberValves == null ? true : icengine.NumberValves >= MinNumberValves);
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
