using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class BaseCostsViewModel : ICosts
    {
        [Required(ErrorMessage ="Введите стоимость услуги")]
        [Display(Name ="Стоимость услуги")]
        //[RegularExpression("",ErrorMessage ="")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Введите время")]
        [Display(Name = "Сколько потребуется времени")]
        public TimeSpan Time { get; set; }
    }
}
