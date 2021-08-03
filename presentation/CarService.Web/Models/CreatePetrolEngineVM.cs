using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CreatePetrolEngineVM
    {
        [Required(ErrorMessage = "Введите название двигателя")]
        [Display(Name = "Название двигателя")]
        public string NameEngine { get; set; }

        [Required(ErrorMessage = "Введите мощность двигателя")]
        [Display(Name = "Мощность в кв")]
        public int EnginePowerKW { get; set; }

        [Required(ErrorMessage = "Введите обьем двигателя")]
        [Display(Name = "Обьем двигателя")]
        public int EngineVolumeSquareCentimeter { get; set; }

        [Required(ErrorMessage = "Введите количество цилиндров")]
        [Display(Name = "Количество цилиндров")]
        public int NumberCylinders { get; set; }

        [Required(ErrorMessage = "Введите количество клапанов")]
        [Display(Name = "Количество клапанов")]
        public int NumberValves { get; set; }
    }
}
