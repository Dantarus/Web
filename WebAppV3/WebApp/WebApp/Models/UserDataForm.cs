using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UserDataForm
    {
        [Required(ErrorMessage ="Pole jest wymagane!")]
        [DataType(DataType.Text)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}