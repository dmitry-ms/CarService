using CarService.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarService.Entities.Users
{
    public class ServiceMan : Person
    {
        public virtual IList<ServiceManRole> _roles {get; private set; } = new List<ServiceManRole>();

        [NotMapped]
        public virtual IList<Enums.ServiceManRole> Roles
        {
            get 
            {
                var result = new List<Enums.ServiceManRole>();          //todo: make it with Linq
                foreach(var r in _roles)
                {
                    result.Add(r.Role);
                }
                return result;
            }
            set 
            {
                foreach(var r in value)                                  //todo: make it with Linq
                {
                    _roles.Add(new ServiceManRole
                    {
                        Id = Guid.NewGuid(),
                        Role = r,
                        ServiceMan = this
                    });
                }
            }
        } 
        public decimal Salary { get; set; }
    }

    public class ServiceManRole : Entity
    {
        public virtual ServiceMan ServiceMan { get; set; }
        public Enums.ServiceManRole Role { get; set; }
    }
}
