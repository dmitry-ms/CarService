using CarService.App.Enums;
using Domain.Enums;

namespace CarService.App.Models
{
    public class ServiceInfoModel
    {
        public string Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public ServiceType ServiceType { get; set; }
        public CostsType CostsType { get; set; }        
        public ParameterType ParameterType { get; set; }
        //public  Orders { get; set; } 
    }
}
