using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class ClientCarService: IClientCarService
    {
        private readonly IClientCarRepository _carRepository;
        public ClientCarService(IClientCarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<ClientCarModel>> GetAllClientCars(Guid clientId)
        {
            var cars = await _carRepository.GetAllClientCars(clientId);
            return ObjectMapper.Mapper.Map<IEnumerable<ClientCarModel>>(cars);
        }
    }
}
