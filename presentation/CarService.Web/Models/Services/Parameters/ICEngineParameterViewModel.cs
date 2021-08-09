using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ICEngineParameterViewModel
    {
        [Range(500, 10000, ErrorMessage = "Выходит за диапазон допустимых значений от 500 - 10000")]
        [Display(Name = "Максимальная мощность двигателя")]
        public int MaxEngineVolume { get; set; }

        [Range(500, 10000, ErrorMessage = "Выходит за диапазон допустимых значений от 500 - 10000")]
        [Display(Name = "Минимальная мощность двигателя")]
        public int MinEngineVolume { get; set; }



        //public int MaxNumberCylinders { get; set; }
        //public int MinNumberCylinders { get; set; }
    }
}
