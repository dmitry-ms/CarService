using CarService.Enums;
using System.Collections.Generic;

namespace CarService.Entities.Users
{
    public class ServiceMan : Person
    {
        //public virtual IList<ServiceManRole> Roles { get; private set; } = new List<ServiceManRole>();
        public decimal Salary { get; set; }
    }
}
