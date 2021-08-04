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
        
        [Required(ErrorMessage ="Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]               
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите пароль")]       
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=\S+$).{6,}$", ErrorMessage = "Пароль должен содержать минимум: 6 символов, 1 цифру и 1 заглавную букву.")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [Required(ErrorMessage = "Введите пароль еще раз")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]        
        public string PasswordConfirm { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Необходимо подтвердить ваше согласие")]
        //public bool ConfirmRules { get; set; }

        public Gender Gender { get; set; }        

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }
    }
}
