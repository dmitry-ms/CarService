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

            CreateMap<EngineInfoModel, EngineInfoVM>();

            CreateMap<DieselEngineVM, DieselEngineModel>().ReverseMap();
            CreateMap<PetrolEngineVM, PetrolEngineModel>().ReverseMap();
            CreateMap<ElectricEngineVM, ElectricEngineModel>().ReverseMap();

            CreateMap<TransmissionInfoModel, TransmissionInfoVM>();

            CreateMap<CreateAutomaticTransmissionVM, AutomaticTransmissionModel>();
            CreateMap<CreateMechanicTransmissionVM, MechanicTransmissionModel>();
            CreateMap<CreateRoboticTransmissionVM, RoboticTransmissionModel>();
            CreateMap<CreateVariatorTransmissionVM, VariatorTransmissionModel>();
        }
    }
}
