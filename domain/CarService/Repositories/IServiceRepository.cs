using CarService.Entities.CarsServices;
using CarService.Repositories.Base;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetServicesAsync(int pageIndex, int pageSize);
    }
}
