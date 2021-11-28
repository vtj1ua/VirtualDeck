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

        public string NameCard { get; set; }
        public string NameUserCard { get; set; }

        public string ImgCard { get; set; }

        public string ImgUserCard { get; set; }

        public int Owner { get; set; }
    }
}