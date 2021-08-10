using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Vehicles;
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

        public Task<IEnumerable<string>> GetBrandNamesAsync()
        {
            return _vehicleRepository.GetBrandNamesAsync();
        }

        public Task<IEnumerable<string>> GetModelNamesAsync(string brand)
        {
            return _vehicleRepository.GetModelNamesAsync(brand);
        }

        public async Task<IEnumerable<Tuple<string,string>>> GetEnginesNamesAsync(string brand, string model)
        {
            return await _vehicleRepository.GetEnginesNamesAsync(brand, model);
        }



        #region Vehicle
        public async Task<IEnumerable<VehicleInfoModel>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<VehicleInfoModel>>(vehicles);
        }

        public async Task<PaginationVehicleModel> GetPaginatetVehiclesAsync(int pageIndex)
        {
            int pageSize = 10;

            var vehiclesCount = await _vehicleRepository.GetCountAsync();
            var paginatedVehicles = await _vehicleRepository.GetVehiclesAsync(pageIndex - 1, pageSize);

            var paginationPage = new PaginationPageModel(vehiclesCount, pageIndex, pageSize);
            var paginationVehicleModel = new PaginationVehicleModel
            {
                Page = paginationPage,
                Vehicles = ObjectMapper.Mapper.Map<IEnumerable<VehicleInfoModel>>(paginatedVehicles)
            };

            return paginationVehicleModel;
        }
        public async Task<VehicleModel> GetVehicleByIdAsync(Guid vehicleId)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
            return ObjectMapper.Mapper.Map<VehicleModel>(vehicle);
        }

        public async Task<VehicleModel> CreateVehicleAsync(EditVehicleModel model)
        {
            var vehicle = new Vehicle
            {
                Engine = await _engineRepository.GetByIdAsync(new Guid(model.EngineId)),
                Transmission = await _transmissionRepository.GetByIdAsync(new Guid(model.TransmissionId)),
                Id = Guid.NewGuid(),
                BrandName = model.BrandName,
                ModelName = model.ModelName,
                AirConditioning = model.AirConditioning
            };
            return ObjectMapper.Mapper.Map<VehicleModel>(await _vehicleRepository.AddAsync(vehicle));  
        }

        public async Task EditVehicleAsync(Guid vehicleId, EditVehicleModel model)
        {
            var vehicle = new Vehicle
            {
                Engine = await _engineRepository.GetByIdAsync(new Guid(model.EngineId)),
                Transmission = await _transmissionRepository.GetByIdAsync(new Guid(model.TransmissionId)),
                Id = vehicleId,
                BrandName = model.BrandName,
                ModelName = model.ModelName,
                AirConditioning = model.AirConditioning
            };
            await _vehicleRepository.UpdateAsync(vehicle);
        }

        public async Task RemoveVehicleAsync(Guid vehicleId)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
            await _vehicleRepository.DeleteAsync(vehicle);
        }
        #endregion

        #region Engine
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
        #endregion

        #region Transmission
        public async Task<IEnumerable<TransmissionInfoModel>> GetAllTransmissionsAsync()
        {
            var transmissions = await _transmissionRepository.GetAllAsync();
            return ObjectMapper.Mapper.Map<IEnumerable<TransmissionInfoModel>>(transmissions);
        }
        public async Task<TransmissionModel> GetTransmissionByIdAsync(Guid transmissionId)
        {
            var transmission = await _transmissionRepository.GetByIdAsync(transmissionId);
            return ObjectMapper.Mapper.Map<TransmissionModel>(transmission);
        }
        public async Task<TransmissionModel> CreateTransmissionAsync(TransmissionModel model)
        {
            model.Id = Guid.NewGuid();
            await _transmissionRepository.AddAsync(ObjectMapper.Mapper.Map<Transmission>(model));
            return model;
        }
        public async Task EditTransmissionAsync(Guid transmissionId, TransmissionModel model)
        {
            model.Id = transmissionId;
            await _transmissionRepository.UpdateAsync(ObjectMapper.Mapper.Map<Transmission>(model));
        }
        public async Task RemoveTransmissionAsync(Guid transmissionId)
        {
            var transmission = await _transmissionRepository.GetByIdAsync(transmissionId);
            await _transmissionRepository.DeleteAsync(transmission);
        }

        
        #endregion
    }
}