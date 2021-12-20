using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class UserCardAssembler
    {
        public UserCardViewModel ConvertENToModelUI(UserCardEN en)
        {
            UserCardViewModel userCard = new UserCardViewModel();
            userCard.Id = en.Id;


            
            userCard.Type = en.Type;
            userCard.Rarity = en.Rarity;
            userCard.Speed = en.Speed;
            userCard.Defense = en.Defense;
            userCard.Attack = en.Attack;
            userCard.Health = en.Health;
            userCard.Level = en.Level;
            userCard.Experience = en.Experience;
            userCard.Name = en.Name;
            userCard.Img = en.Img;
            userCard.PurchaseDate = (DateTime)en.PurchaseDate;


            switch (en.Type)
            {
                case CardTypeEnum.Electric:
                    userCard.BackgroundColorClass = "electric";
                    break;
                case CardTypeEnum.Fire:
                    userCard.BackgroundColorClass = "fire";
                    break;
                case CardTypeEnum.Water:
                    userCard.BackgroundColorClass = "water";
                    break;
                case CardTypeEnum.Poison:
                    userCard.BackgroundColorClass = "poison";
                    break;
                case CardTypeEnum.Psychic:
                    userCard.BackgroundColorClass = "psychic";
                    break;
                case CardTypeEnum.Normal:
                    userCard.BackgroundColorClass = "normal";
                    break;
                case CardTypeEnum.Ground:
                    userCard.BackgroundColorClass = "ground";
                    break;
                case CardTypeEnum.Rock:
                    userCard.BackgroundColorClass = "rock";
                    break;
                case CardTypeEnum.Ice:
                    userCard.BackgroundColorClass = "ice";
                    break;
                case CardTypeEnum.Grass:
                    userCard.BackgroundColorClass = "grass";
                    break;
                case CardTypeEnum.Ghost:
                    userCard.BackgroundColorClass = "ghost";
                    break;
                case CardTypeEnum.Flying:
                    userCard.BackgroundColorClass = "flying";
                    break;
                case CardTypeEnum.Fighting:
                    userCard.BackgroundColorClass = "fighting";
                    break;
                case CardTypeEnum.Dragon:
                    userCard.BackgroundColorClass = "dragon";
                    break;
                case CardTypeEnum.Bug:
                    userCard.BackgroundColorClass = "bug";
                    break;
            }

            int rarity = 0;

            switch (en.Rarity)
            {
                case RarityEnum.Basic:
                    userCard.BackgroundImage = "Basic.png";
                    userCard.Rareza = "Básica";
                    rarity = 5;
                    break;
                case RarityEnum.Common:
                    userCard.BackgroundImage = "Common.png";
                    userCard.Rareza = "Común";
                    rarity = 10;
                    break;
                case RarityEnum.Uncommon:
                    userCard.BackgroundImage = "Uncommon.png";
                    userCard.Rareza = "Poco común";
                    rarity = 20;
                    break;
                case RarityEnum.Rare:
                    userCard.BackgroundImage = "Rare.png";
                    userCard.Rareza = "Raro";
                    rarity = 40;
                    break;
                case RarityEnum.Epic:
                    userCard.BackgroundImage = "Epic.png";
                    userCard.Rareza = "Épico";
                    rarity = 80;
                    break;
                case RarityEnum.Legendary:
                    userCard.BackgroundImage = "Legendary.png";
                    userCard.Rareza = "Legendaria";
                    rarity = 160;
                    break;
                case RarityEnum.Mythical:
                    userCard.BackgroundImage = "Mythical.png";
                    userCard.Rareza = "Mítica";
                    rarity = 320;
                    break;
                default:
                    userCard.BackgroundImage = "Common.png";
                    userCard.Rareza = "Básica";
                    break;
            }
            userCard.Tokens = en.Card.Price * 0.10f + userCard.Level * rarity;

            return userCard;


        }
        public IList<UserCardViewModel> ConvertListENToModel(IList<UserCardEN> ens)
        {
            IList<UserCardViewModel> userCards = new List<UserCardViewModel>();
            foreach (UserCardEN en in ens)
            {
                userCards.Add(ConvertENToModelUI(en));
            }
            return userCards;
        }
    }
}