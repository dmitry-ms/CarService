using CarService.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class RegistrationClientVM
    {         
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string PasswordConfirm { get; set; }

        public Gender Gender { get; set; }             // Is this OK?

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }
    }
}
