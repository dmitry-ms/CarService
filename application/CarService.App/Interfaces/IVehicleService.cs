using CarService.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleInfoModel>> GetAllVehiclesAsync();
        public Task<PaginationVehicleModel> GetPaginatetVehiclesAsync(int page);
        public Task<VehicleModel> GetVehicleByIdAsync(Guid vehicleId);
        public Task<VehicleModel> CreateVehicleAsync(EditVehicleModel model);
        public Task EditVehicleAsync(Guid vehicleId, EditVehicleModel model);
        public Task RemoveVehicleAsync(Guid endineId);

        public Task<IEnumerable<EngineInfoModel>> GetAllEnginesAsync();
        public Task<EngineModel> GetEngineByIdAsync(Guid engineId);
        public Task<EngineModel> CreateEngineAsync(EngineModel model);
        public Task EditEngineAsync(Guid engineId, EngineModel model);
        public Task RemoveEngineAsync(Guid endineId);

        public Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissionsAsync();
        public Task<TransmissionModel> GetTransmissionByIdAsync(Guid transmissionId);
        public Task<TransmissionModel> CreateTransmissionAsync(TransmissionModel model);
        public Task EditTransmissionAsync(Guid transmissionId, TransmissionModel model);
        public Task RemoveTransmissionAsync(Guid transmissionId);
       
    }
}
