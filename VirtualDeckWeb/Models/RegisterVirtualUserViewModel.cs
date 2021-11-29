using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class RegisterVirtualUserViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        //[StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Username { get; set; }
    }
}