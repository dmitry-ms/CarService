using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Vehicles.Parts.Engines;
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
        public async Task<IEnumerable<VehicleInfoModel>> GetAllVehicles()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<VehicleInfoModel>>(vehicles);
        }
        public async Task<IEnumerable<EngineInfoModel>> GetAllEngines()
        {
            var engines = await _engineRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<EngineInfoModel>>(engines);
        }
        public async Task<EngineModel> CreateEngineAsync(EngineModel model)
        {
            model.Id = Guid.NewGuid();
            await _engineRepository.AddAsync(ObjectMapper.Mapper.Map<Engine>(model));
            return model;
        }
        public async Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissions()
        {
            var transmissions = await _transmissionRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<TransmissionInfoModel>>(transmissions);
        }      
        
    }
}
