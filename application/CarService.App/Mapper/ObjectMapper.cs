using AutoMapper;
using CarService.App.Models;
using CarService.Entities.Users;
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
        }
    }
}
