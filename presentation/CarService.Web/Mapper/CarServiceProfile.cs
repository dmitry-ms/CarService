using AutoMapper;
using CarService.Web.Models;
using CarService.App.Models;

namespace CarService.Web.Mapper
{
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
        {
            CreateMap<RegistrationClientVM, RegistrationClientModel>(); //.ReverseMap();
            CreateMap<ClientCarModel, ClientCarVM>();
        }
    }
}
