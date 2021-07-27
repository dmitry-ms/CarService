using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.CarsServices;
using CarService.Repositories;

namespace CarService.Data.EF.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(CarServiceDbContext dbContext) : base(dbContext) { }
    }
}
