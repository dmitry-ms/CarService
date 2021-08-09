using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ElectricEngineVM
    {
        [Display(Name = "Название двигателя")]
        [Required(ErrorMessage = "Введите название двигателя")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        [Remote(action: "CheckNameEngine", controller: "Engine", ErrorMessage = "Такой двигатель уже существует")]
        public string NameEngine { get; set; }

        [Display(Name = "Мощность в кв")]
        [Required(ErrorMessage = "Введите мощность двигателя")]
        [Range(1, 1000, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 1000")]
        public int EnginePowerKW { get; set; }

        [Display(Name = "Емкость батареи")]
        [Required(ErrorMessage = "Введите емкость батареи")]       
        [Range(10, 100, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 100")]
        public int BatteryCapacity { get; set; }
    }
}
