using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ServiceViewModel
    {
        [Display(Name = "Название услуги")]
        public string ServiceName { get; set; }

        [Display(Name = "Описание услуги")]
        public string Description { get; set; }
    }
}
