using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public enum ParameterTypeViewModel
    {
        [Display(Name = "Без ограничений")]
        WithOutParameters = 0,

        [Display(Name = "С двигателем по названию")]
        EngineName = 1,

        [Display(Name = "С двигателем внутреннего сгорания")]
        ICEngine = 2,

        [Display(Name = "С дизельным двигателем")]
        DieselEngine = 3,

        [Display(Name = "С бензиновым двигателем")]
        PetrolEngine = 4,

        [Display(Name = "С электро двигателем")]
        ElectricEngine = 5        
    }
}
