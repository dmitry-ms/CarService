using CarService.Entities.Vehicles;
using CarService.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetVehicleListAsync();
        Task<IEnumerable<Vehicle>> GetVehicleByBrandNameAsync(string brandName);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(int pageIndex, int pageSize);

        Task<IEnumerable<string>> GetBrandNamesAsync();
        Task<IEnumerable<string>> GetModelNamesAsync(string brand);
        Task<IEnumerable<Tuple<string, string>>> GetEnginesNamesAsync(string brand, string model);


        //Task<Vehicle> GetVehicleWithEngineAsync(int vehicleId);        
        //Task<IEnumerable<Vehicle>> GetVehicleByEngineAsync(int engineId);
    }
}
