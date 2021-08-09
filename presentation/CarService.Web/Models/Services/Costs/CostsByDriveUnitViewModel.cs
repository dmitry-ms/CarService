using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class CostsByDriveUnitViewModel : ICosts
    {
        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="Введите стоимость")]
        [Display(Name ="Цена за полный привод")]
        public decimal PriceByFourWheelDrive { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Введите стоимость")]
        [Display(Name = "Цена за передний привод или моно (если задний не указан)")]
        public decimal PriceByFrontWheelDriveOrMono { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Цена за задний привод")]
        public decimal? PriceByRearWheelDrive { get; set; }

        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Введите время")]
        [Display(Name = "Время на полный привод")]
        public TimeSpan TimeByFourWheelDrive { get; set; }

        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Введите время")]
        [Display(Name = "Время на передний привод или моно (если задний не указан)")]
        public TimeSpan TimeByFrontWheelDriveOrMono { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Время на задний привод")]
        public TimeSpan? TimeByRearWheelDrive { get; set; }
    }
}
