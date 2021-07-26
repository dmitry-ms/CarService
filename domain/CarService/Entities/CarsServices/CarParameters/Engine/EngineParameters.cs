using CarService.Entities.Vehicles;
using CarService.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Entities.CarsServices.CarParameters.Engine
{
    public class EngineParameters : IParameters
    {
        public virtual IList<string> EngineNames { get; set; } = new List<string>();

        public virtual bool IsAvailableFor(ClientCar car)
        {
            var engine = car.Vehicle.Engine;
            bool result = true;
            if (EngineNames != null)
            {
                result = EngineNames.ToList().Exists(n => n.ToLower() == engine.NameEngine.ToLower()); //TODO: is it right?
            }
            return result;
        }
    }
}
