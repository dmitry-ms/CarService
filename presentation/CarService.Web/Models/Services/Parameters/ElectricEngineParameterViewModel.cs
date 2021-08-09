using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ElectricEngineParameterViewModel
    {
        [Range(10, 100, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 100")]
        [Display(Name = "Максимальный обьем батареи")]
        public int? MaxBatteryCapacity { get; set; }

        [Range(10, 100, ErrorMessage = "Выходит за диапазон допустимых значений от 1 - 100")]
        [Display(Name = "Минимальный обьем батареи")]
        public int? MinBatteryCapacity { get; set; }
    }
}
