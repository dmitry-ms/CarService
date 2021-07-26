using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class LoginVM
    {
        [BindRequired]
        public string Email { get; set; }

        [BindRequired]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

