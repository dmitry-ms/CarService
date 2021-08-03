using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public enum DriveUnitVM
    {
        [Display(Name = "Полный")]
        FourWheelDrive,
        [Display(Name = "Передний")]
        FrontWheelDrive,
        [Display(Name = "Задний")]
        RearWheelDrive
    }
}
