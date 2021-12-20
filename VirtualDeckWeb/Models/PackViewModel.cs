using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class PackViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }

        public double Price { get; set; }

        public string Img { get; set; }

        public DateTime RegistryDate { get; set; }

        public int MaxNumCards { get; set; }


        public int MinNumCards { get; set; }

        public RarityEnum Rarity { get; set; }
        public CardTypeEnum CardTypes { get; set; }
        public RarityEnum CardRarities { get; set; }
    }
}