using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Vehicles;
using CarService.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Data.EF.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarServiceDbContext dbContext) : base(dbContext)
        { }


        public async Task<IEnumerable<string>> GetBrandNamesAsync()
        {
            return await _dbContext
                .Vehicles
                .Select(v => v.BrandName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetModelNamesAsync(string brand)
        {
            return await _dbContext
                .Vehicles
                .Where(v => v.BrandName == brand)
                .Select(v => v.ModelName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<Tuple<string,string>>> GetEnginesNamesAsync(string brand, string model)
        {
            return await _dbContext
                .Vehicles
                .Where(v => v.BrandName == brand && v.ModelName == model)
                .Select(c => new Tuple<string, string>(c.Engine.NameEngine, c.Id.ToString()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(int pageIndex, int pageSize)
        {
            return await _dbContext
                .Vehicles
                .OrderBy(p => p.BrandName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }


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
