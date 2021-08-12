using CarService.App.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IServiceManager
    {
        Task<PaginationServiceModel> GetPaginatetServicesAsync(int page);
        Task<IEnumerable<GroupedServices>> GetServicesGroupedByType();
        Task<IEnumerable<CarServicesModel>> GetAllServicesForCarAsync(string carId);
        Task<ServiceInfoModel> CreateServiceAsync(CommonEditServiceModel model);
        Task AddOrderAsync(Guid carId, IEnumerable<Guid> servicesIdList);
        Task<ServiceModel> GetServiceByIdAsync(string serviceId);    
        Task<ServiceBasketModel> GetTotalCostsAsync(IEnumerable<Guid> servicesId, Guid carId);
        Task<ServiceModel> EditServiceAsync(string serviceId, EditServiceModel model);
        Task RemoveServiceAsync(string vehicleId);
    }
}
