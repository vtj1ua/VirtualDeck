
using VirtualDeckWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckWeb.Assemblers
{
    public class CardAssembler
    {
        public CardsViewModels ConvertENToModelUI(CardEN en)
        {
            CardsViewModels card = new CardsViewModels();
            card.IdCard = en.Id;
            card.ImgCard = en.Img;
            card.NameCard = en.Name;
            card.CardDescription = en.Description;
            card.PriceCard = en.Price;

            card.TypeCard = en.Type;
            card.HealthCard = en.Health;
            card.AttackCard = en.Attack;
            card.DefenseCard = en.Defense;
            card.SpeedCard = en.Speed;
            card.RarityCard = en.Rarity;

            return card;
        }
        public IList<CardsViewModels> ConvertListENToModel(IList<CardEN> ens)
        {
            IList<CardsViewModels> cards = new List<CardsViewModels>();
            foreach (CardEN en in ens)
            {
                cards.Add(ConvertENToModelUI(en));
            }
            return cards;
        }
    }
}