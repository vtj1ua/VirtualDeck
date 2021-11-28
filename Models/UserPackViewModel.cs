using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class UserPackViewModel
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PackTypeEnum Type { get; set; }
    }
}