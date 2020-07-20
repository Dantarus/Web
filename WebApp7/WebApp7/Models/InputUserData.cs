using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp7.Models
{
    public class InputUserData
    {
        public int Id { get; set; }
        [DisplayName("Login")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [MaxLength(10)]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [DisplayName("Hasło")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Potwierdź Hasło")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}