using CarService.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleInfoModel>> GetAllVehiclesAsync();
        public Task<IEnumerable<EngineInfoModel>> GetAllEnginesAsync();
        public Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissionsAsync();
        public Task<EngineModel> GetEngineByIdAsync(Guid engineId);
        public Task<EngineModel> CreateEngineAsync(EngineModel model);
        public Task EditEngineAsync(Guid engineId, EngineModel model);
        public Task RemoveEngineAsync(Guid endineId);
        public Task<TransmissionModel> CreateTransmissionAsync(TransmissionModel model);
    }
}
