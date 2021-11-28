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

        public string Img { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        //public DateTime RegistryDate { get; set; }

        public CardTypeEnum Type { get; set; }


        public int Health { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }


        public int Speed { get; set; }

        public CardRarityEnum Rarity { get; set; }
    }
}