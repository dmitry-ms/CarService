using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CarService.Interfaces;

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





        public async Task<EngineModel> CreateEngine(EngineModel model)
        {
            model.Id = Guid.NewGuid();
            await _engineRepository.AddAsync(ObjectMapper.Mapper.Map<Engine>(model));
            await _engineRepository.SaveChangesAsync();
            return model;
        }
        public async Task<IEnumerable<EngineInfoModel>> GetAllEngines()
        {
            var engines = await _engineRepository.GetAllAsync();            
            return ObjectMapper.Mapper.Map<IEnumerable<EngineInfoModel>>(engines); 
        }
 



        //public async Task<DieselEngineModel> CreateDieselEngine(DieselEngineModel model)
        //{
        //    model.Id = Guid.NewGuid();
        //    _engineRepository.AddAsync()

        //}
        //public async Task<PetrolEngineModel> CreatePetrolEngine(PetrolEngineModel model)
        //{
        //    model.Id = Guid.NewGuid();
        //}
        //public async Task<ElectricEngineModel> CreateElectricEngine(ElectricEngineModel model)
        //{
        //    model.Id = Guid.NewGuid();
        //}


    }
}
