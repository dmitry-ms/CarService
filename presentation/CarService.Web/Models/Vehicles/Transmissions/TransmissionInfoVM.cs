using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class TransmissionInfoVM
    {        
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Привод")]
        public DriveUnitVM DriveUnit { get; set; }

        [Display(Name = "Тип")]
        public TransmissionTypeVM TransmissionType { get; set; }
    }
}
