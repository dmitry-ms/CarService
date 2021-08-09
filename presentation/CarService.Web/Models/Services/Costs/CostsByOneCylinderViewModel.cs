using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CostsByOneCylinderViewModel 
    {
        [Display(Name ="Стоимость за один цилиндр")]
        public decimal PriceByOneCylinder { get; set; }

        [Display(Name = "Время на один цилиндр")]
        public TimeSpan TimeByOneCylinder { get; set; }
    }
}
