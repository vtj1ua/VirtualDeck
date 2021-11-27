using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace VirtualDeckWeb.Models
{
    public class VirtualUserViewModel : RegisterViewModel
{
    [Required]
    [Display(Name = "Nombre Usuario")]

    public string userName { get; set; }

    [Display(Name = "Id Usuario")]

    public int Id { get; }


}
}