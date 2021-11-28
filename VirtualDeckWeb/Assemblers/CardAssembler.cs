using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class CardAssembler
    {
        public CardViewModel ConvertENToModelUI(CardEN en)
        {
            CardViewModel card = new CardViewModel();
            card.Id = en.Id;
            card.Name = en.Name;
            card.Description = en.Description;
            card.Price = en.Price;
            card.Img = en.Img;
            //card.RegistryDate = en.RegistryDate;
            card.Type = en.Type;
            card.Health = en.Health;
            card.Attack = en.Attack;
            card.Defense = en.Defense;
            card.Speed = en.Speed;
            card.Rarity = en.Rarity;
            return card;


        }
        public IList<CardViewModel> ConvertListENToModel(IList<CardEN> ens)
        {
            IList<CardViewModel> cards = new List<CardViewModel>();
            foreach (CardEN en in ens)
            {
                cards.Add(ConvertENToModelUI(en));
            }
            return cards;
        }
    }
}