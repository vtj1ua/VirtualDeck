﻿using System;
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

            switch (en.Rarity)
            {
                case RarityEnum.Basic:
                    userCard.BackgroundImage = "Basic.png";
                    break;
                case RarityEnum.Common:
                    userCard.BackgroundImage = "Common.png";
                    break;
                case RarityEnum.Uncommon:
                    userCard.BackgroundImage = "Uncommon.png";
                    break;
                case RarityEnum.Rare:
                    userCard.BackgroundImage = "Rare.png";
                    break;
                case RarityEnum.Epic:
                    userCard.BackgroundImage = "Epic.png";
                    break;
                case RarityEnum.Legendary:
                    userCard.BackgroundImage = "Legendary.png";
                    break;
                case RarityEnum.Mythical:
                    userCard.BackgroundImage = "Mythical.png";
                    break;
                default:
                    userCard.BackgroundImage = "Common.png";
                    break;
            }

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