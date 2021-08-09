using CarService.Entities.CarsServices;
using CarService.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetServicesAsync(int pageIndex, int pageSize);
    }
}
