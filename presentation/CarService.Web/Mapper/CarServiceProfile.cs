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
            CreateMap<RegistrationClientVM, RegistrationClientModel>(); //.ReverseMap();
            CreateMap<ClientCarModel, ClientCarVM>();
            CreateMap<CarServiceUser, UserVM>();

            
            CreateMap<VehicleInfoModel, VehicleInfoVM>();

            CreateMap<PaginationPageModel, PaginationPageViewModel>();
            CreateMap<PaginationVehicleModel, PaginationVehicleViewModel>();

            CreateMap<EditVehicleVM, EditVehicleModel>();
            CreateMap<VehicleModel, EditVehicleVM>()
                .ForMember(v => v.EngineId, opt => opt.MapFrom(v => v.Engine.Id))
                .ForMember(v => v.TransmissionId, opt => opt.MapFrom(v => v.Transmission.Id));

            
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

        }
    }
}
