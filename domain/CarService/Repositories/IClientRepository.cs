using CarService.Entities.Users;
using CarService.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        public Task<IEnumerable<Client>> GetClientByCarBrandNameAsync(string carBrandName);

        public Task<IEnumerable<Client>> GetClientListAsync();
    }
}
