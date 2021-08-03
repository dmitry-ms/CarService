using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class VehicleInfoVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Бренд")]
        public string BrandName { get; set; }

        [Display(Name = "Модель")]
        public string ModelName { get; set; }
        [Display(Name = "двигателя")]
        public EngineInfoVM Engine { get; set; }
        //public TransmissionInfoModel Transmission { get; set; }
        [Display(Name = "Кондиционер")]
        public bool AirConditioning { get; set; }
    }
}
