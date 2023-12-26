using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllServices.Models
{
    public class LoginDetails
    {
        [Required(ErrorMessage = "Please Enter Your UserId!")]
        [Display(Name = "Enter email:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password!")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}