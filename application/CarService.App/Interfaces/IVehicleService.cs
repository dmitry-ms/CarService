using CarService.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IVehicleService
    {
        public Task<EngineModel> CreateEngine(EngineModel model);
        public Task<IEnumerable<EngineInfoModel>> GetAllEngines();
    }
}
