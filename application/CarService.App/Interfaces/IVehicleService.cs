using CarService.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleInfoModel>> GetAllVehicles();
        public Task<IEnumerable<EngineInfoModel>> GetAllEngines();
        public Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissions();
        public Task<EngineModel> CreateEngineAsync(EngineModel model);        
    }
}
