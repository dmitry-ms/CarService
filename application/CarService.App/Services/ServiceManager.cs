using CarService.App.Enums;
using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.CarsServices;
using CarService.Entities.CarsServices.CarParameters;
using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.CarsServices.Costs;
using CarService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Task<ServiceModel> CreateServiceAsync(EditServiceModel model)
        {
            throw new NotImplementedException();
        }      

        public async Task<ServiceInfoModel> CreateServiceAsync(CommonEditServiceModel model)
        {
            var service = ObjectMapper.Mapper.Map<Service>(model.service);
            service.Id = Guid.NewGuid();

            var costs = SelectCosts(model);            
            costs.Id = Guid.NewGuid();
            service.Costs = costs;

            var parameters = SelectParameters(model);
            if(parameters !=null)parameters.Id = Guid.NewGuid();
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
            int pageSize = 10;

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
