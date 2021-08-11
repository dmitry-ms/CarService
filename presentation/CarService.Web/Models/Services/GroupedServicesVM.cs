using System.Collections.Generic;

namespace CarService.Web.Models
{
    public class GroupedServicesVM
    {
        public ServiceTypeViewModel ServiceType { get; set; }

        public IEnumerable<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();
    }
}
