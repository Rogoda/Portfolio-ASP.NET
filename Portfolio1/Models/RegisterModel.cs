using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio1.Models
{
    public class RegisterModel
    {
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Proszę podać prawidłowy adres e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać login.")]
        [MinLength(5,ErrorMessage ="Login jest za krórki , musi mieć co najmniej 5 znaków.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [MinLength(5, ErrorMessage = "Hasło jest zbyt krótkie, musi mieć co najmniej 5 znaków")]
        public string Password { get; set; }

        public string Password2 { get; set; }
    }
}