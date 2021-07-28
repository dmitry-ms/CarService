using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public enum EngineTypeVM
    {
        [Display(Name="Дизель")]
        DieselEngine,

        [Display(Name = "Бензин")]
        PetrolEngine,

        [Display(Name = "Електро")]
        ElectricEngine
    }
}
