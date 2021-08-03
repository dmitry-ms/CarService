using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public enum TransmissionTypeVM
    {
        [Display(Name = "Автомат")]
        Automatic,     

        [Display(Name = "Механика")]
        Mechanic,

        [Display(Name = "Робот")]
        Robotic,

        [Display(Name = "Вариатор")]
        Variator
    }
}
