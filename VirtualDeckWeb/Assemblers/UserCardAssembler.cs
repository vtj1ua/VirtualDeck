using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
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