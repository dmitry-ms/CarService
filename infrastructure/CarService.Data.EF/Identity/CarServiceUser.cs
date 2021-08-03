﻿using CarService.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;

namespace CarService.Data.EF.Identity
{
    public class CarServiceUser : IdentityUser
    {
        public CarServiceUser() { }
        public CarServiceUser(string userName) : base(userName) { }
        public Guid? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
