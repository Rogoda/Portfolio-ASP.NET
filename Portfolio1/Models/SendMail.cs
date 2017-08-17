using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio1.Models
{
    public class SendMail
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Proszę podać prawidłowy adres e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wiadomość jest pusta.")]
        public string Message { get; set; }
    }
}