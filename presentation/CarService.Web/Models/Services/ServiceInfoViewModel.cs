using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ServiceInfoViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Название услуги")]        
        public string ServiceName { get; set; }

        [Display(Name = "Описание услуги")]
        public string Description { get; set; }

        [Display(Name = "Тип услуги")]
        public ServiceTypeViewModel ServiceType { get; set; }

        [Display(Name = "Тип расходов")] // (зависимость цены и времени от параметров автомобиля)
        public CommonCostsTypesVM CostsType { get; set; }

        [Display(Name = "Зависимость от параметров")]
        public ParameterTypeViewModel ParameterType { get; set; }
    }
}
