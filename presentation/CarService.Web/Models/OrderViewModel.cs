using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        [Display(Name ="Дата добавления")]
        public DateTime DateAdded { get; set; }

        [Display(Name ="Автомобиль")]
        public ClientCarVM Car { get; set; }        //todo: заменить на ClientCarInfoVM!!!

        [Display(Name ="Заказанные услуги")]
        public virtual IEnumerable<ServiceInfoViewModel> Services { get; set; } = new List<ServiceInfoViewModel>();
    }
}
