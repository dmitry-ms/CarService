using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Users;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Data.EF.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(CarServiceDbContext dbContext) : base(dbContext)
        { }

        public Task<IEnumerable<Client>> GetClientByCarBrandNameAsync(string carBrandName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetClientListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
