using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class EngineInfoVM
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string NameEngine { get; set; }

        [Display(Name = "Мощность")]
        public int EnginePowerKW { get; set; }

        [Display(Name = "Тип")]
        public EngineTypeVM EngineType { get; set; }
    }
}
