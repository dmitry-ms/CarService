using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Vehicles.Parts.Transmissions;
using CarService.Repositories;

namespace CarService.Data.EF.Repository
{
    public class TransmissionRepository : Repository<Transmission>, ITransmissionRepository
    {
        public TransmissionRepository(CarServiceDbContext dbContext) : base(dbContext) { }
    }
}
