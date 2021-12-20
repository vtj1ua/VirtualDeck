using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class TokenPackViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Tokens { get; set; }

        [Required(ErrorMessage = "Debes introducir el número de la tarjeta de crédito")]
        [Display(Name = "Número de la tarjeta")]
        //[Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Debes introducir la fecha de caducidad de la tarjeta")]
        [Display(Name = "Fecha de caducidad")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^([0-2][0-9]|(3)[0-1])(/)(((0)[0-9])|((1)[0-2]))(/)\d{4}$", ErrorMessage = "El formato de la fecha debe ser DD/MM/YYYY")]
        public Nullable<DateTime> ExpiryDate { get; set; }
        [Required(ErrorMessage = "Debes introducir el CVV")]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
        [Required(ErrorMessage = "Debes introducir el nombre del titular de la tarjeta")]
        [Display(Name = "Titular de la tarjeta")]
        public string AccountHolder { get; set; }
    }
}