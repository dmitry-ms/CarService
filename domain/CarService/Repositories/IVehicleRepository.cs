﻿using CarService.Entities.Vehicles;
using CarService.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetVehicleListAsync();
        Task<IEnumerable<Vehicle>> GetVehicleByBrandNameAsync(string brandName);


        //Task<Vehicle> GetVehicleWithEngineAsync(int vehicleId);              //example
        //Task<IEnumerable<Vehicle>> GetVehicleByEngineAsync(int engineId);
    }
}
