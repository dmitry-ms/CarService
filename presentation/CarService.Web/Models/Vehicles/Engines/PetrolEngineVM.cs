using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class PetrolEngineVM
    {
        [Display(Name = "Название двигателя")]
        [Required(ErrorMessage = "Введите название двигателя")]
        [Remote(action: "CheckNameEngine", controller: "Engine", ErrorMessage = "Такой двигатель уже существует")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]

        public string NameEngine { get; set; }

        [Display(Name = "Мощность в кв")]
        [Required(ErrorMessage = "Введите мощность двигателя")]
        [Range(1, 1000, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 1000")]
        public int EnginePowerKW { get; set; }

        [Required(ErrorMessage = "Введите обьем двигателя")]
        [Display(Name = "Обьем двигателя")]
        [Range(500, 10000, ErrorMessage = "Выходит за диапазон допустимых значений от 500 - 10000")]
        public int EngineVolumeSquareCentimeter { get; set; }

        [Required(ErrorMessage = "Введите количество цилиндров")]
        [Display(Name = "Количество цилиндров")]
        [Range(1, 12, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 12")]
        public int NumberCylinders { get; set; }

        [Required(ErrorMessage = "Введите количество клапанов")]
        [Display(Name = "Количество клапанов")]
        [Range(2, 48, ErrorMessage = "Выходит за диапазон допустимых значений от 2 - 48")]
        public int NumberValves { get; set; }
    }
}
