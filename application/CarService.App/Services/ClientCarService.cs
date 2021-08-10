using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Vehicles;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class ClientCarService: IClientCarService
    {
        private readonly IClientCarRepository _carRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityService _identityService;
        public ClientCarService(IClientCarRepository carRepository, IVehicleRepository vehicleRepository, 
            IClientRepository clientRepository, IIdentityService identityService)
        {
            _carRepository = carRepository;
            _vehicleRepository = vehicleRepository;
            _clientRepository = clientRepository;
            _identityService = identityService;
        }

        public async Task AddClientCarAsync(AddClientCarModel model)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(new Guid(model.VehicleId));
            var personId = await _identityService.GetUserPersonIdAsync(model.UserId);
            var client = await _clientRepository.GetByIdAsync(new Guid(personId));
            var clientCarEntity = ObjectMapper.Mapper.Map<ClientCar>(model);
            clientCarEntity.Id = Guid.NewGuid();
            clientCarEntity.Vehicle = vehicle;
            clientCarEntity.Client = client;

            await _carRepository.AddAsync(clientCarEntity);
        }

        public async Task<IEnumerable<ClientCarModel>> GetAllClientCars(string userId)
        {
            var personId = await _identityService.GetUserPersonIdAsync(userId);
            var cars = await _carRepository.GetAllClientCars(new Guid(personId));
            return ObjectMapper.Mapper.Map<IEnumerable<ClientCarModel>>(cars);
        }
    }
}
