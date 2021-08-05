using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class VariatorTransmissionVM
    {
        [Display(Name = "Название коробки передач")]
        [Required(ErrorMessage = "Введите название коробки передач")]
        [Remote(action: "CheckNameTransmission", controller: "Transmission", ErrorMessage = "Такая коробка передач уже существует")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        public string Name { get; set; }

        [Display(Name = "Привод")]
        [Required(ErrorMessage = "Выберите привод")]
        public DriveUnitVM DriveUnit { get; set; }
    }
}
