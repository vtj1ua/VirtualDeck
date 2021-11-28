
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

            switch (en.Type)
            {
                case CardTypeEnum.Electric: 
                    card.BackgroundColorClass = "electric";
                    break;
                case CardTypeEnum.Fire:
                    card.BackgroundColorClass = "fire";
                    break;
                case CardTypeEnum.Water:
                    card.BackgroundColorClass = "water";
                    break;
                case CardTypeEnum.Poison:
                    card.BackgroundColorClass = "poison";
                    break;
                case CardTypeEnum.Psychic:
                    card.BackgroundColorClass = "psychic";
                    break;
                case CardTypeEnum.Normal:
                    card.BackgroundColorClass = "normal";
                    break;
                case CardTypeEnum.Ground:
                    card.BackgroundColorClass = "ground";
                    break;
                case CardTypeEnum.Rock:
                    card.BackgroundColorClass = "rock";
                    break;
                case CardTypeEnum.Ice:
                    card.BackgroundColorClass = "ice";
                    break;
                case CardTypeEnum.Grass:
                    card.BackgroundColorClass = "grass";
                    break;
                case CardTypeEnum.Ghost:
                    card.BackgroundColorClass = "ghost";
                    break;
                case CardTypeEnum.Flying:
                    card.BackgroundColorClass = "flying";
                    break;
                case CardTypeEnum.Fighting:
                    card.BackgroundColorClass = "fighting";
                    break;
                case CardTypeEnum.Dragon:
                    card.BackgroundColorClass = "dragon";
                    break;
                case CardTypeEnum.Bug:
                    card.BackgroundColorClass = "bug";
                    break;
            }

            switch (en.Rarity)
            {
                case RarityEnum.Basic: 
                    card.BackgroundImage = "Basic.png";
                    break;
                case RarityEnum.Common:
                    card.BackgroundImage = "Common.png";
                    break;
                case RarityEnum.Uncommon:
                    card.BackgroundImage = "Uncommon.png";
                    break;
                case RarityEnum.Rare:
                    card.BackgroundImage = "Rare.png";
                    break;
                case RarityEnum.Epic:
                    card.BackgroundImage = "Epic.png";
                    break;
                case RarityEnum.Legendary:
                    card.BackgroundImage = "Legendary.png";
                    break;
                case RarityEnum.Mythical:
                    card.BackgroundImage = "Mythical.png";
                    break;
                default:
                    card.BackgroundImage = "Common.png";
                    break;
            }

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