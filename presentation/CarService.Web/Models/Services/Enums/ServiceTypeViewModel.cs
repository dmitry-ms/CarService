using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public enum ServiceTypeViewModel
    {
        [Display(Name = "Ремонт кузова")]
        BodyService,

        [Display(Name = "Ремонт и обслуживание тормозной системы")]
        BrakeSystemService,

        [Display(Name = "Ремонт и обслуживание шасси")]
        ChassisService,

        [Display(Name = "Ремонт и обслуживание климатической системы")]
        ClimateSystemService,

        [Display(Name = "Ремонт електрики")]
        ElectricianService,

        [Display(Name = "Ремонт и обслуживание двигателя")]
        EngineService,

        [Display(Name = "Ремонт внутренней отделки")]
        InteriorService,

        [Display(Name = "Ремонт рулевого управления")]
        SteeringSystemService, 

        [Display(Name = "Ремонт и обслуживание трансмисии")]
        TransmissionService
    }
}
