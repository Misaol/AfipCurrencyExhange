using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AfipCurrencyExhange.Models
{
    public class Login
    {
        [Required(ErrorMessage="El usuario es obligatorio.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }
    }
}
