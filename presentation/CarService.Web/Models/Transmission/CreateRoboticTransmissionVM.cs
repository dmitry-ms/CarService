using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CreateRoboticTransmissionVM
    {
        [Required(ErrorMessage = "Введите название коробки передач")]
        [Display(Name = "Название коробки передач")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите привод")]
        [Display(Name = "Привод")]
        public DriveUnitVM DriveUnit { get; set; }

        [Required(ErrorMessage = "Введите количество передач")]
        [Display(Name = "Количество передач")]
        public int NumberOfGears { get; set; }
    }
}
