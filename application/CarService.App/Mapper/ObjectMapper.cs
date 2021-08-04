using AutoMapper;
using CarService.App.Enums;
using CarService.App.Models;
using CarService.Entities.Users;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;
using CarService.Interfaces;
using System;

namespace CarService.App.Mapper
{
    public static class ObjectMapper 
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CarServiceDtoMapper>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class CarServiceDtoMapper : Profile
    {
        public CarServiceDtoMapper()
        {
            CreateMap<RegistrationClientModel, Client>();             //.ForMember(...).ReverseMap();
            CreateMap<ClientCar, ClientCarModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Vehicle.BrandName))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Vehicle.ModelName))
                .ForMember(dest => dest.MileageKM, opt => opt.MapFrom(src => src.MileageKM));

            CreateMap<Vehicle, VehicleInfoModel>();
            
            CreateMap<EngineModel, Engine>()
                .Include<DieselEngineModel, DieselEngine>()
                .Include<PetrolEngineModel, PetrolEngine>()
                .Include<ElectricEngineModel, ElectricEngine>()
                .ReverseMap();
            CreateMap<DieselEngineModel, DieselEngine>().ReverseMap();
            CreateMap<PetrolEngineModel, PetrolEngine>().ReverseMap();
            CreateMap<ElectricEngineModel, ElectricEngine>().ReverseMap();
            CreateMap<Engine, EngineInfoModel>()
                .BeforeMap<ConvertEngineTypeToEnumAction>();

            CreateMap<TransmissionModel, Transmission>()
                .Include<AutomaticTransmissionModel, AutomaticTransmission>()
                .Include<MechanicTransmissionModel, MechanicTransmission>()
                .Include<RoboticTransmissionModel, RoboticTransmission>()
                .Include<VariatorTransmissionModel, VariatorTransmission>()
                .ReverseMap();
            CreateMap<AutomaticTransmissionModel, AutomaticTransmission>().ReverseMap();
            CreateMap<MechanicTransmissionModel, MechanicTransmission>().ReverseMap();
            CreateMap<RoboticTransmissionModel, RoboticTransmission>().ReverseMap();
            CreateMap<VariatorTransmissionModel, VariatorTransmission>().ReverseMap();
            CreateMap<Transmission, TransmissionInfoModel>()
                .BeforeMap<ConvertTransmissionTypeToEnumAction>();
        }

        private class ConvertEngineTypeToEnumAction : IMappingAction<Engine, EngineInfoModel>
        {
            public void Process(Engine source, EngineInfoModel destination, ResolutionContext context)
            {
                switch (source)
                {
                    case IDieselEngine:
                        destination.EngineType = EngineType.Diesel;
                        break;
                    case IPetrolEngine:
                        destination.EngineType = EngineType.Petrol;
                        break;
                    case IElectricEngine:
                        destination.EngineType = EngineType.Electric;
                        break;
                }                
            }
        } 
        
        private class ConvertTransmissionTypeToEnumAction : IMappingAction<Transmission, TransmissionInfoModel>
        {
            public void Process(Transmission source, TransmissionInfoModel destination, ResolutionContext context)
            {
                switch (source)
                {
                    case IAutomaticTransmission:
                        destination.TransmissionType = TransmissionType.Automatic;
                        break;
                    case IMechanicTransmission:
                        destination.TransmissionType = TransmissionType.Mechanic;
                        break;
                    case IRoboticTransmission:
                        destination.TransmissionType = TransmissionType.Robotic;
                        break;
                    case IVariatorTransmission:
                        destination.TransmissionType = TransmissionType.Variator;
                        break;
                }
            }
        }
    }
}
