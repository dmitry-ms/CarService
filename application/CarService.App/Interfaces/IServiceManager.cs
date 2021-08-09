using CarService.App.Models;
using CarService.App.Models.Base;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IServiceManager
    {
        Task<PaginationServiceModel> GetPaginatetServicesAsync(int page);
        Task<ServiceInfoModel> CreateServiceAsync(CommonEditServiceModel model);
        Task<ServiceModel> GetServiceByIdAsync(string serviceId);
        Task<ServiceModel> EditServiceAsync(string serviceId, EditServiceModel model);
        Task RemoveServiceAsync(string vehicleId);
    }
}
