using CarService.Entities.Base;
using CarService.Enums;
using System;

namespace CarService.Entities.Users
{
    public abstract class Person : Entity //todo: maybe move it to "base" folder
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
    }
}
