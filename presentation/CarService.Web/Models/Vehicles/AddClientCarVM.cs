using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class AddClientCarVM
    {
        [Display(Name = "Двигатель")]
        [Required(ErrorMessage = "Выберите двигатель")]
        public string VehicleId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Марка автомобиля")]
        [Required(ErrorMessage = "Выберите марку автомобиля")]
        public string Brand { get; set; }

        [Display(Name = "Модель автомобиля")]
        [Required(ErrorMessage = "Выберите модель автомобиля")]
        public string Model { get; set; }

        [Display(Name = "Год производства")]
        [Required(ErrorMessage = "Введите год производства автомобиля")]
        public DateTime YearProduction { get; set; }

        [Display(Name = "Актуальный пробег")]
        [RegularExpression(@"(^\d{3,6})|\s$", ErrorMessage = "Должно быть от 3 до 6 цифр")]
        public int? MileageKM { get; set; }

        [Display(Name = "VIN номер")]
        public string VinNumber { get; set; }

        [Display(Name = "Номер государственной регистрации")]
        public string CarPlate { get; set; }

        [Display(Name = "Цвет")]
        public string Color { get; set; }

        //public string Engine { get; set; }
    }
}
