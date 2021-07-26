using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Vehicles;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Data.EF.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarServiceDbContext dbContext) :base(dbContext)
        { }

        public Task<IEnumerable<Vehicle>> GetVehicleByBrandNameAsync(string brandName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehicleListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
