using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    
    public enum CommonCostsTypesVM
    {
        [Display(Name = "Стоимость и время не зависят от параметров автомобиля")]
        BaseCost = 0,

        [Display(Name = "Стоимость и время зависят от привода автомобиля")]
        CostByDriveUnit = 1,

        [Display(Name = "Стоимость и время зависят от количества цилиндров двигателя")]
        CostByOneCylinder = 2
    }
}
