using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class DieselEngineParameterViewModel
    {
        [Display(Name = "Только с AdBlue")]
        public bool DEF { get; set; }
    }
}
