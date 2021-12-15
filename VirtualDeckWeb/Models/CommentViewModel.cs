using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debes escribir un texto para publicar el comentario")]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [Display(Name = "Texto del comentario")]
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
    }
}