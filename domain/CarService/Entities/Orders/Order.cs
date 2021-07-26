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
        public ClientCar Car { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public string Comment { get; set; }
    }
}
