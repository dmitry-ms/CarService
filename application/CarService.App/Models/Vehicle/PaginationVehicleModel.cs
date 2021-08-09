using System.Collections.Generic;

namespace CarService.App.Models
{
    public class PaginationVehicleModel
    {
        public IEnumerable<VehicleInfoModel> Vehicles { get; set; }
        public PaginationPageModel Page { get; set; }
    }
}
