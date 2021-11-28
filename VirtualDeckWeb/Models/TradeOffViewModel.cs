using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class TradeOffViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TradeStateEnum State { get; set; }
    }
}