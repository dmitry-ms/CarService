using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CarServicesViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string ServiceName { get; set; }


        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Требуемое время")]
        public TimeSpan RequiredTime { get; set; }

        [Display(Name = "Тип")]
        public ServiceTypeViewModel ServiceType { get; set; }
    }
}
