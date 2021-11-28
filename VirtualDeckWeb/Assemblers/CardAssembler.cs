
using VirtualDeckWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

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

            //card.TypeCard = en.Type;
            card.HealthCard = en.Health;
            card.AttackCard = en.Attack;
            card.DefenseCard = en.Defense;
            card.SpeedCard = en.Speed;

            switch (en.Type)
            {
                case CardTypeEnum.Electric: 
                    card.TypeCard = "electric";
                    break;
                case CardTypeEnum.Fire:
                    card.TypeCard = "fire";
                    break;
                case CardTypeEnum.Water:
                    card.TypeCard = "water";
                    break;
                case CardTypeEnum.Poison:
                    card.TypeCard = "poison";
                    break;
                case CardTypeEnum.Psychic:
                    card.TypeCard = "psychic";
                    break;
                case CardTypeEnum.Normal:
                    card.TypeCard = "normal";
                    break;
                case CardTypeEnum.Ground:
                    card.TypeCard = "ground";
                    break;
                case CardTypeEnum.Rock:
                    card.TypeCard = "rock";
                    break;
                case CardTypeEnum.Ice:
                    card.TypeCard = "ice";
                    break;
                case CardTypeEnum.Grass:
                    card.TypeCard = "grass";
                    break;
                case CardTypeEnum.Ghost:
                    card.TypeCard = "ghost";
                    break;
                case CardTypeEnum.Flying:
                    card.TypeCard = "flying";
                    break;
                case CardTypeEnum.Fighting:
                    card.TypeCard = "fighting";
                    break;
                case CardTypeEnum.Dragon:
                    card.TypeCard = "dragon";
                    break;
                case CardTypeEnum.Bug:
                    card.TypeCard = "bug";
                    break;
            }




            switch (en.Rarity)
            {
                case CardRarityEnum.Basic: 
                    card.RarityCard = "Basic.png";
                    break;
                case CardRarityEnum.Common:
                    card.RarityCard = "Common.png";
                    break;
                case CardRarityEnum.Uncommon:
                    card.RarityCard = "Uncommon.png";
                    break;
                case CardRarityEnum.Rare:
                    card.RarityCard = "Rare.png";
                    break;
                case CardRarityEnum.Epic:
                    card.RarityCard = "Epic.png";
                    break;
                case CardRarityEnum.Legendary:
                    card.RarityCard = "Legendary.png";
                    break;
                case CardRarityEnum.Mythical:
                    card.RarityCard = "Mythical.png";
                    break;
                default:
                    card.RarityCard = "Common.png";
                    break;
            }

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