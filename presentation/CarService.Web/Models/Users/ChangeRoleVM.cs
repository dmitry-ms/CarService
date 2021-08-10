using CarService.Data.EF.Identity;
using System;
using System.Collections.Generic;

public class ChangeRoleVM
{
    public string UserId { get; set; }
    public string UserEmail { get; set; }
    public IList<CarServiceRole> AllRoles { get; set; } = new List<CarServiceRole>();
    public IList<string> UserRoles { get; set; } = new List<string>();
}