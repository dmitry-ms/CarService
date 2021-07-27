using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Repositories;

namespace CarService.Data.EF.Repository
{
    public class EngineRepository : Repository<Engine>, IEngineRepository
    {
        public EngineRepository(CarServiceDbContext dbContext) : base(dbContext) { }
    }
}
