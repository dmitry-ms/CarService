using System.Collections.Generic;

namespace CarService.Web.Models
{
    public class PaginationVehicleViewModel
    {
        public IEnumerable<VehicleInfoVM> Vehicles { get; set; }
        public PaginationPageViewModel Page { get; set; }
    }
}
