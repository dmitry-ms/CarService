using System.Collections.Generic;

namespace CarService.Web.Models
{
    public class PaginationServiceViewModel
    {
        public IEnumerable<ServiceInfoViewModel> Services { get; set; } = new List<ServiceInfoViewModel>();
        public PaginationPageViewModel Page { get; set; }
    }
}
