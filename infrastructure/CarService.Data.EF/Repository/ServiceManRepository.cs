using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Users;
using CarService.Repositories;

namespace CarService.Data.EF.Repository
{
    public class ServiceManRepository : Repository<ServiceMan>, IServiceManRepository
    {
        public ServiceManRepository(CarServiceDbContext dbContext) : base(dbContext) { }
    }
}
