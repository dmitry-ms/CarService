using CarService.Entities.Base;
using CarService.Entities.CarsServices;
using CarService.Entities.Vehicles;
using System;
using System.Collections.Generic;

namespace CarService.Entities.Orders
{
    public class Order : Entity
    {
        public DateTime DateAdded { get; set; }
        public virtual ClientCar Car { get; set; }
        public virtual IList<Service> Services { get; set; } = new List<Service>();
        public string Comment { get; set; }
    }
}
