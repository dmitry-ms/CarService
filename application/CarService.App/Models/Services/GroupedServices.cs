using Domain.Enums;
using System.Collections.Generic;

namespace CarService.App.Models
{
    public class GroupedServices
    {
        public ServiceType ServiceType { get; set; }

        public IEnumerable<ServiceModel> Services { get; set; } = new List<ServiceModel>();
    }
}
