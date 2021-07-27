using CarService.Entities.Vehicles;
using CarService.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IClientCarRepository : IRepository<ClientCar>
    {
        public Task<IEnumerable<ClientCar>> GetAllClientCars(Guid clientId);
    }
}
