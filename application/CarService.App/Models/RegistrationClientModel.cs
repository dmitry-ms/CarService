using CarService.App.Models.Base;
using CarService.Enums;
using System;

namespace CarService.App.Models
{
    public class RegistrationClientModel : BaseRegistrationModel
    {
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
    }
}
