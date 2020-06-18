using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWebApp.Models
{
    public class EmployeeModel
    {
        [Display(Name ="Employee ID")]
        [Range(100000,999999,ErrorMessage ="You need to enter a valid EmployeeId")]
        public int EmployeeId { get; set;}

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="You need to provide use your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to provide use your last name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name ="Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "The email and confirm email must match")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength =10,ErrorMessage ="You need to provide a long enought password.")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Your password and confirmed password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
