using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class VirtualUserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string Pass { get; set; }

        [Display(Prompt = "Nombre de usuario", Description = "Nombre de usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre")]
        [StringLength(200, MinimumLength = 4,
                  ErrorMessage = "Debe tener mínimo 4 caracteres")]
        public string UserName { get; set; }

        [ScaffoldColumn(false)]
        public string Email { get; set; }


        [Display(Prompt = "Descripción del usuario", Description = "Descripción del usuario", Name = "Descripción ")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripcion no puede tener más de 400 caracteres")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public int Tokens { get; set; }

        [Display(Prompt = "Imagen del usuario", Description = "Imagen del usuario", Name = "Imagen ")]
        [StringLength(maximumLength: 200, ErrorMessage = "La imagen no puede tener más de 200 caracteres")]
        public string Img { get; set; }

        [ScaffoldColumn(false)]
        public int CombatStatus { get; set; }

        [ScaffoldColumn(false)]
        public int NumCards { get; set; }

        [ScaffoldColumn(false)]
        public string DeletedImg { get; set; }

    }
}