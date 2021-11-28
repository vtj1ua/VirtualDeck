using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class UserCardViewModel
    {
        public int Id { get; set; }
        public CardTypeEnum Type { get; set; }
        public CardRarityEnum Rarity { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}