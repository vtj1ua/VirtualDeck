using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class TradeOffViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TradeStateEnum State { get; set; }

        public VirtualUserEN Owner { get; set; }

        public UserCardViewModel OfferedUserCard { get; set; }

        public CardViewModel DesiredCard { get; set; }
    }
}