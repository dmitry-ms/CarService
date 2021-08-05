using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class EditVehicleVM
    {
        [Display(Name = "Марка автомобиля")]
        [Required(ErrorMessage = "Введите марку автомобиля")]        
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символов")]
        public string BrandName { get; set; }

        [Display(Name = "Модель автомобиля")]
        [Required(ErrorMessage = "Введите модель автомобиля")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символов")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Выберете двигатель или создайте")]
        [Display(Name = "Двигатель")]
        public string EngineId { get; set; }

        [Required(ErrorMessage = "Выберете коробку передач или создайте")]
        [Display(Name = "Коробка передач")]
        public string TransmissionId { get; set; }

        [Display(Name = "Кондиционер")]
        public bool AirConditioning { get; set; }
    }
}
