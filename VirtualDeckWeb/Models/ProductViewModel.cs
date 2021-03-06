using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public string Img { get; set; }

        public DateTime RegistryDate { get; set; }
    }
}