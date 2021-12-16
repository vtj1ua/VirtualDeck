using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class AttackMoveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardTypeEnum Type { get; set; }
        public string Description { get; set; }
    }
}