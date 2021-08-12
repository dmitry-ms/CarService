using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ClientCarVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Модель")]
        public string BrandName { get; set; }
        [Display(Name = "Марка")]
        public string ModelName { get; set; }
        [Display(Name ="Пробег:")]
        public int MileageKM { get; set; }
    }
}
