using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CreateVehicleVM
    {
        [Required(ErrorMessage = "Введите марку автомобиля")]
        [Display(Name = "Марка автомобиля")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Введите модель автомобиля")]
        [Display(Name = "Модель автомобиля")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Выберете двигатель или создайте")]
        [Display(Name = "Двигатель")]
        public string EngineId { get; set; }

        //[Required(ErrorMessage = "Выберете коробку передач или создайте")]
        //[Display(Name = "Коробка передач")]
        //public string TransmissionId { get; set; }

        [Display(Name = "Кондиционер")]
        public bool AirConditioning { get; set; }
    }
}
