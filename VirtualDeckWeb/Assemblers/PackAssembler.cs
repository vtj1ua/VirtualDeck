using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class PackAssembler
    {
        public PackViewModel ConvertENToModelUI(PackEN en)
        {
            PackViewModel pack = new PackViewModel();
            pack.Id = en.Id;
            pack.Name = en.Name;
            pack.Description = en.Description;
            pack.Price = en.Price;
            pack.RegistryDate = (DateTime)en.RegistryDate;
            pack.MaxNumCards = en.MaxNumCards;
            pack.MinNumCards = en.MinNumCards;
            
/*
            switch (en.CardTypes)
            {
                case CardTypeEnum.Electric:
                    pack.CardTypes = "electric";
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
*/
            switch (en.Rarity)
            {
                case RarityEnum.Basic:
                    pack.Img = "Basic.png";
                    break;
                case RarityEnum.Common:
                    pack.Img = "Common.png";
                    break;
                case RarityEnum.Uncommon:
                    pack.Img = "Uncommon.png";
                    break;
                case RarityEnum.Rare:
                    pack.Img = "Rare.png";
                    break;
                case RarityEnum.Epic:
                    pack.Img = "Epic.png";
                    break;
                case RarityEnum.Legendary:
                    pack.Img = "Legendary.png";
                    break;
                case RarityEnum.Mythical:
                    pack.Img = "Mythical.png";
                    break;
                default:
                    pack.Img = "Common.png";
                    break;
            }
            return pack;


        }
        public IList<PackViewModel> ConvertListENToModel(IList<PackEN> ens)
        {
            IList<PackViewModel> packs = new List<PackViewModel>();
            foreach (PackEN en in ens)
            {
                packs.Add(ConvertENToModelUI(en));
            }
            return packs;
        }


        /*

        public PackViewModel ConvertUserPackENToModelUI(UserPackEN en)
        {
            PackViewModel userPack = new PackViewModel();
            userPack.Id = en.Id;
            switch (en.Rarity)
            {
                case RarityEnum.Basic:
                    userPack.Img = "Basic.png";
                    break;
                case RarityEnum.Common:
                    userPack.Img = "Common.png";
                    break;
                case RarityEnum.Uncommon:
                    userPack.Img = "Uncommon.png";
                    break;
                case RarityEnum.Rare:
                    userPack.Img = "Rare.png";
                    break;
                case RarityEnum.Epic:
                    userPack.Img = "Epic.png";
                    break;
                case RarityEnum.Legendary:
                    userPack.Img = "Legendary.png";
                    break;
                case RarityEnum.Mythical:
                    userPack.Img = "Mythical.png";
                    break;
                default:
                    userPack.Img = "Common.png";
                    break;
            }
            return userPack;


        }
        public IList<PackViewModel> ConvertListUserPackENToModel(IList<UserPackEN> ens)
        {
            IList<PackViewModel> userPacks = new List<PackViewModel>();
            foreach (UserPackEN en in ens)
            {
                userPacks.Add(ConvertUserPackENToModelUI(en));
            }
            return userPacks;
        }*/
    }
}