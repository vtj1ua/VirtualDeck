using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class UserPackAssembler
    {
        public UserPackViewModel ConvertENToModelUI(UserPackEN en)
        {
            UserPackViewModel userPack = new UserPackViewModel();
            userPack.Id = en.Id;
            userPack.Name = en.Name;
            userPack.PurchaseDate = (DateTime)en.PurchaseDate;
            userPack.Rarity = en.Rarity;
            
            switch (en.Rarity)
            {
                case RarityEnum.Basic:
                    userPack.Img = "Basic.png";
                    userPack.Rareza = "Básica";
                    break;
                case RarityEnum.Common:
                    userPack.Img = "Common.png";
                    userPack.Rareza = "Común";
                    break;
                case RarityEnum.Uncommon:
                    userPack.Img = "Uncommon.png";
                    userPack.Rareza = "Poco común";
                    break;
                case RarityEnum.Rare:
                    userPack.Img = "Rare.png";
                    userPack.Rareza = "Raro";
                    break;
                case RarityEnum.Epic:
                    userPack.Img = "Epic.png";
                    userPack.Rareza = "Épico";
                    break;
                case RarityEnum.Legendary:
                    userPack.Img = "Legendary.png";
                    userPack.Rareza = "Legendaria";
                    break;
                case RarityEnum.Mythical:
                    userPack.Img = "Mythical.png";
                    userPack.Rareza = "Mítica";
                    break;
                default:
                    userPack.Img = "Common.png";
                    userPack.Rareza = "Básica";
                    break;
            }
            return userPack;


        }
        public IList<UserPackViewModel> ConvertListENToModel(IList<UserPackEN> ens)
        {
            IList<UserPackViewModel> userPacks = new List<UserPackViewModel>();
            foreach (UserPackEN en in ens)
            {
                userPacks.Add(ConvertENToModelUI(en));
            }
            return userPacks;
        }
    }
}