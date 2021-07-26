using CarService.Entities.Vehicles;
using System.Collections.Generic;

namespace CarService.Entities.Users
{
    public class Client : Person
    {
        public virtual IList<ClientCar> ClientCars { get; private set; } 
            = new List<ClientCar>();
    }
}
