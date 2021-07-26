using Microsoft.AspNetCore.Identity;

namespace CarService.Data.EF.Identity
{
    public class CarServiceRole : IdentityRole
    {
        public CarServiceRole() { }
        public CarServiceRole(string roleName): base(roleName) { }
    }
}
