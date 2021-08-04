using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ElectricEngineVM
    {
        [Required(ErrorMessage = "Введите название двигателя")]
        [Display(Name = "Название двигателя")]
        public string NameEngine { get; set; }

        [Required(ErrorMessage = "Введите мощность двигателя")]
        [Display(Name = "Мощность в кв")]
        public int EnginePowerKW { get; set; }

        [Required(ErrorMessage = "Введите емкость батареи")]
        [Display(Name = "Емкость батареи")]
        public int BatteryCapacity { get; set; }
    }
}
