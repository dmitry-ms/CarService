using System.Collections.Generic;

namespace CarService.App.Models
{
    public class PaginationServiceModel
    {
        public IEnumerable<ServiceInfoModel> Services { get; set; }
        public PaginationPageModel Page { get; set; }
    }
}
