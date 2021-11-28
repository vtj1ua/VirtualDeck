using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class VirtualUserViewModel
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Tokens { get; set; }
        public string Img { get; set; }
        public int CombatStatus { get; set; }
        public int NumCards { get; set; }

    }
}