using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.CarsServices;
using CarService.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Data.EF.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(CarServiceDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Service>> GetServicesAsync(int pageIndex, int pageSize)
        {
            return await _dbContext.Services.OrderBy(p => p.ServiceName)
                                .Skip(pageIndex * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }
    }
}
