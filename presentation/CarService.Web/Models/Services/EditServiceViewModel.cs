using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class EditServiceViewModel
    {
        [Display(Name = "Название услуги")]
        [Required(ErrorMessage = "Введите название услуги")]
        //[Remote(action: "CheckNameService", controller: "Service", ErrorMessage = "Такая услуга уже существует")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]
        public string ServiceName { get; set; }

        [Display(Name = "Описание услуги")]
        [Required(ErrorMessage = "Введите описание услуги")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 500 символов")]
        public string Description { get; set; }

        [Display(Name = "Тип услуги")]
        [Required(ErrorMessage = "Выберите тип услуги")]
        public ServiceTypeViewModel ServiceType { get; set; }

        [Display(Name = "Тип расходов (зависимость цены и времени от параметров автомобиля)")]
        public CommonCostsTypesVM CostsType { get; set; }

        [Display(Name = "Ограничения по параметрам")]
        public ParameterTypeViewModel ParameterType { get; set; }
    }
}
