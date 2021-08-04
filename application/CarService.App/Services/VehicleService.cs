using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEngineRepository _engineRepository;
        private readonly ITransmissionRepository _transmissionRepository;
        public VehicleService(IVehicleRepository vehicleRepository, 
            IEngineRepository engineRepository,
            ITransmissionRepository transmissionRepository)
        {
            _vehicleRepository = vehicleRepository;
            _engineRepository = engineRepository;
            _transmissionRepository = transmissionRepository;
        }
        public async Task<IEnumerable<VehicleInfoModel>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<VehicleInfoModel>>(vehicles);
        }
        public async Task<IEnumerable<EngineInfoModel>> GetAllEnginesAsync()
        {
            var engines = await _engineRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<EngineInfoModel>>(engines);
        }
        public async Task<EngineModel> GetEngineByIdAsync(Guid engineId)
        {
            var engine = await _engineRepository.GetByIdAsync(engineId);
            return ObjectMapper.Mapper.Map<EngineModel>(engine);
        }
        public async Task<EngineModel> CreateEngineAsync(EngineModel model)
        {
            model.Id = Guid.NewGuid();
            await _engineRepository.AddAsync(ObjectMapper.Mapper.Map<Engine>(model));
            return model;
        }
        public async Task EditEngineAsync(Guid engineId, EngineModel model)
        {
            model.Id = engineId;
            await _engineRepository.UpdateAsync(ObjectMapper.Mapper.Map<Engine>(model));
        }
        public async Task RemoveEngineAsync(Guid engineId)
        {
            var engine = await _engineRepository.GetByIdAsync(engineId);
            await _engineRepository.DeleteAsync(engine);
        }
        public async Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissionsAsync()
        {
            var transmissions = await _transmissionRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<TransmissionInfoModel>>(transmissions);
        }

        public async Task<TransmissionModel> CreateTransmissionAsync(TransmissionModel model)
        {
            model.Id = Guid.NewGuid();
            await _transmissionRepository.AddAsync(ObjectMapper.Mapper.Map<Transmission>(model));
            return model;
        }
    }
}
