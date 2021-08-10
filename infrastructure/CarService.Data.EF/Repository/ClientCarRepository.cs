using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Vehicles;
using CarService.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Data.EF.Repository
{
    public class ClientCarRepository : Repository<ClientCar>, IClientCarRepository
    {
        public ClientCarRepository(CarServiceDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<ClientCar>> GetAllClientCars(Guid clientId)
        {
            return await _dbContext.ClientCars
                .Where(c => c.Client.Id == clientId).ToListAsync();
        }
    }
}
