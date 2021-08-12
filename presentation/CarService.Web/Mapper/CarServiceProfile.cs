using AutoMapper;
using CarService.Web.Models;
using CarService.App.Models;
using CarService.Data.EF.Identity;

namespace CarService.Web.Mapper
{
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
        {
            CreateMap<PaginationPageModel, PaginationPageViewModel>();

            CreateMap<RegistrationClientVM, RegistrationClientModel>();
            
            CreateMap<ClientCarModel, ClientCarVM>();
            CreateMap<AddClientCarVM, AddClientCarModel>();
            
            CreateMap<CarServiceUser, UserVM>();

            CreateMap<OrderModel, OrderViewModel>();

            CreateMap<CommonEditServiceViewModel, CommonEditServiceModel>();
            CreateMap<PaginationServiceModel, PaginationServiceViewModel>();
            CreateMap<ServiceInfoModel, ServiceInfoViewModel>();
            CreateMap<CarServicesModel, CarServicesViewModel>();
            CreateMap<GroupedServices, GroupedServicesVM>();                          //удалить если получится с IGrouping
            CreateMap<ServiceViewModel, ServiceModel>().ReverseMap();
            CreateMap<EditServiceViewModel, EditServiceModel>();                      //проверить нужна ли эта связка
            CreateMap<ServiceBasketModel, ServiceBasketViewModel>();

            #region Vehicle
            CreateMap<PaginationVehicleModel, PaginationVehicleViewModel>();
            CreateMap<VehicleInfoModel, VehicleInfoVM>();            
            CreateMap<EditVehicleVM, EditVehicleModel>();
            CreateMap<VehicleModel, EditVehicleVM>()
                .ForMember(v => v.EngineId, opt => opt.MapFrom(v => v.Engine.Id))
                .ForMember(v => v.TransmissionId, opt => opt.MapFrom(v => v.Transmission.Id));
            #endregion

            #region Engine
            CreateMap<EngineInfoModel, EngineInfoVM>();

            CreateMap<DieselEngineVM, DieselEngineModel>().ReverseMap();
            CreateMap<PetrolEngineVM, PetrolEngineModel>().ReverseMap();
            CreateMap<ElectricEngineVM, ElectricEngineModel>().ReverseMap();

            CreateMap<DieselEngineModel, EditDieselEngineVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.NameEngine))
                .ReverseMap();
            CreateMap<PetrolEngineModel, EditPetrolEngineVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.NameEngine))
                .ReverseMap();
            CreateMap<ElectricEngineModel, EditElectricEngineVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.NameEngine))
                .ReverseMap();
            #endregion

            #region Transmission
            CreateMap<TransmissionInfoModel, TransmissionInfoVM>();

            CreateMap<AutomaticTransmissionVM, AutomaticTransmissionModel>().ReverseMap();
            CreateMap<MechanicTransmissionVM, MechanicTransmissionModel>().ReverseMap();
            CreateMap<RoboticTransmissionVM, RoboticTransmissionModel>().ReverseMap();
            CreateMap<VariatorTransmissionVM, VariatorTransmissionModel>().ReverseMap();

            CreateMap<AutomaticTransmissionModel, EditAutomaticTransmissionVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.Name))
                .ReverseMap();
            CreateMap<MechanicTransmissionModel, EditMechanicTransmissionVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.Name))
                .ReverseMap();
            CreateMap<RoboticTransmissionModel, EditRoboticTransmissionVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.Name))
                .ReverseMap();
            CreateMap<VariatorTransmissionModel, EditVariatorTransmissionVM>()
                .ForMember(t => t.OldName, opt => opt.MapFrom(t => t.Name))
                .ReverseMap();
            #endregion

            #region Costs
            CreateMap<BaseCostsViewModel, CostsModel>();
            CreateMap<CostsByOneCylinderViewModel, CostsByOneCylinderModel>();
            CreateMap<CostsByDriveUnitViewModel, CostsByDriveUnitModel>();
            #endregion

            #region Parameters
            CreateMap<DieselEngineParameterViewModel, DieselEngineParametersModel>();
            CreateMap<PetrolEngineParameterViewModel, PetrolEngineParametersModel>();
            CreateMap<ElectricEngineParameterViewModel, ElectricEngineParametersModel>();
            CreateMap<EngineParameterViewModel, EngineParametersModel>();
            CreateMap<ICEngineParameterViewModel, ICEngineParametersModel>();
            #endregion
        }
    }
}
