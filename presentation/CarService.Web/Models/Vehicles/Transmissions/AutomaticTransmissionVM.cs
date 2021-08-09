using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class AutomaticTransmissionVM
    {
        [Display(Name = "Название коробки передач")]
        [Required(ErrorMessage = "Введите название коробки передач")]
        [Remote(action: "CheckNameTransmission", controller: "Transmission", ErrorMessage = "Такая коробка передач уже существует")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        public string Name { get; set; }

        [Display(Name = "Привод")]
        [Required(ErrorMessage = "Выберите привод")]        
        public DriveUnitVM DriveUnit { get; set; }

        [Display(Name = "Количество передач")]
        [Required(ErrorMessage = "Введите количество передач")]
        [Range(2, 20, ErrorMessage = "Выходит за диапазон допустимых значений от 2 - 20")]
        public int NumberOfGears { get; set; }
    }
}
