using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AfipCurrencyExhange.Models
{
    public class Symbols
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int CurencyID { get; set; }
    }
}
