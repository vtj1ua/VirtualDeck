using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}