using CarService.App.Enums;
using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.CarsServices;
using CarService.Entities.CarsServices.CarParameters;
using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.CarsServices.Costs;
using CarService.Entities.Orders;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IClientCarRepository _clientCarRepository;
        private readonly IOrderRepository _orderRepository;

        public ServiceManager(IServiceRepository serviceRepository,
            IClientCarRepository clientCarRepository,
            IOrderRepository orderRepository)
        {
            _clientCarRepository = clientCarRepository;
            _serviceRepository = serviceRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<CarServicesModel>> GetAllServicesForCarAsync(string carId)
        {
            var carEntity = await _clientCarRepository.GetByIdAsync(new Guid(carId));
            var services = await _serviceRepository.GetAllAsync();

            return services.Where(s => s.IsAvailableFor(carEntity))
                .Select(s => new CarServicesModel
                {
                    Id = s.Id,
                    ServiceName = s.ServiceName,
                    Description = s.Description,
                    ServiceType = s.ServiceType,
                    Price = s.GetPrice(carEntity),
                    RequiredTime = s.GetRequiredTime(carEntity)
                })
                .ToList();
            #region Comment
            //var carServices = new List<CarServicesModel>();
            //foreach (var service in services)
            //{
            //    if (service.IsAvailableFor(carEntity))
            //    {
            //        var carServiceModel = new CarServicesModel
            //        {
            //            Id = service.Id,
            //            ServiceName = service.ServiceName,
            //            Description = service.Description,
            //            ServiceType = service.ServiceType,
            //            Price = service.GetPrice(carEntity),
            //            RequiredTime = service.GetRequiredTime(carEntity)
            //        };
            //        carServices.Add(carServiceModel);
            //    }
            //}
            //return carServices;
            #endregion
        }

        public async Task AddOrderAsync(Guid carId, IEnumerable<Guid> servicesIdList)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                DateAdded = DateTime.UtcNow,
                Car = await _clientCarRepository.GetByIdAsync(carId),
                Services = await _serviceRepository.GetAllByIdAsync(servicesIdList)
            };

            await _orderRepository.AddAsync(order);
        }

        public async Task<IEnumerable<GroupedServices>> GetServicesGroupedByType()
        {
            var services = ObjectMapper.Mapper.Map<IEnumerable<ServiceModel>>(await _serviceRepository.GetAllAsync());

            return services.GroupBy(s => s.ServiceType)
                .Select(g => new GroupedServices
                {
                    ServiceType = g.Key,
                    Services = g.ToList()
                });
        }

        public async Task<ServiceInfoModel> CreateServiceAsync(CommonEditServiceModel model)
        {
            var service = ObjectMapper.Mapper.Map<Service>(model.service);
            service.Id = Guid.NewGuid();

            var costs = SelectCosts(model);
            costs.Id = Guid.NewGuid();
            service.Costs = costs;

            var parameters = SelectParameters(model);
            if (parameters != null) parameters.Id = Guid.NewGuid();
            service.Costs.CarParameters = parameters;

            var resultEntity = await _serviceRepository.AddAsync(service);

            return ObjectMapper.Mapper.Map<ServiceInfoModel>(resultEntity);
        }

        public Task<ServiceModel> EditServiceAsync(string serviceId, EditServiceModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationServiceModel> GetPaginatetServicesAsync(int pageIndex)
        {
            int pageSize = 4;

            var serviceCount = await _serviceRepository.GetCountAsync();
            var paginatedServices = await _serviceRepository.GetServicesAsync(pageIndex - 1, pageSize);

            var paginationPage = new PaginationPageModel(serviceCount, pageIndex, pageSize);
            var paginationServiceModel = new PaginationServiceModel
            {
                Page = paginationPage,
                Services = ObjectMapper.Mapper.Map<IEnumerable<ServiceInfoModel>>(paginatedServices)
            };

            return paginationServiceModel;
        }

        public async Task<ServiceModel> GetServiceByIdAsync(string id)
        {
            return ObjectMapper.Mapper.Map<ServiceModel>(await _serviceRepository.GetByIdAsync(new Guid(id)));
        }

        public async Task<ServiceBasketModel> GetTotalCostsAsync(IEnumerable<Guid> servicesId, Guid carId)
        {
            var car = await _clientCarRepository.GetByIdAsync(carId);
            var serviceBasket = new ServiceBasketModel();
            var listServices = new List<CarServicesModel>();

            decimal totalPrice = 0;
            TimeSpan totalTime = new TimeSpan(0);

            foreach(var item in servicesId)
            {
                var serviceEntity = await _serviceRepository.GetByIdAsync(item);
                var service = new CarServicesModel
                {
                    Id = serviceEntity.Id,
                    ServiceType = serviceEntity.ServiceType,
                    ServiceName = serviceEntity.ServiceName,
                    Description = serviceEntity.Description,
                    Price = serviceEntity.Costs.GetPrice(car),
                    RequiredTime = serviceEntity.Costs.GetRequiredTime(car)
                };
                listServices.Add(service);
                totalPrice += service.Price;
                totalTime += service.RequiredTime;
            }
            serviceBasket.Services = listServices;
            serviceBasket.TotalPrice = totalPrice;
            serviceBasket.TotalTime = totalTime;

            return serviceBasket;
        }

        public async Task RemoveServiceAsync(string id)
        {
            var service = await _serviceRepository.GetByIdAsync(new Guid(id));
            await _serviceRepository.DeleteAsync(service);
        }

        private BaseCosts SelectCosts(CommonEditServiceModel model)
        {
            switch (model.service.CostsType)
            {
                case CostsType.CostByDriveUnit:
                    return ObjectMapper.Mapper.Map<CostsByDriveUnit>(model.costsByDriveUnit);
                case CostsType.CostByOneCylinder:
                    return ObjectMapper.Mapper.Map<CostsByOneCylinder>(model.costsByOneCylinder);
                default:
                    return ObjectMapper.Mapper.Map<Costs>(model.baseCost);
            }
        }
        private Parameters SelectParameters(CommonEditServiceModel model)
        {
            switch (model.service.ParameterType)
            {
                case ParameterType.DieselEngine:
                    return ObjectMapper.Mapper.Map<DieselEngineParameters>(model.parameterDieselEngine);
                case ParameterType.ElectricEngine:
                    return ObjectMapper.Mapper.Map<ElectricEngineParameters>(model.parameterElectricEngine);
                case ParameterType.EngineName:
                    return ObjectMapper.Mapper.Map<EngineParameters>(model.parameterEngine);
                case ParameterType.ICEngine:
                    return ObjectMapper.Mapper.Map<ICEngineParameters>(model.parameterICEngine);
                case ParameterType.PetrolEngine:
                    return ObjectMapper.Mapper.Map<PetrolEngineParameters>(model.parameterPetrolEngine);
                default:
                    return null;
            }
        }
    }
}
