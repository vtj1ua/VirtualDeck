using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class UserPackAssembler
    {
        public UserPackViewModel ConvertENToModelUI(UserPackEN en)
        {
            UserPackViewModel userPack = new UserPackViewModel();
            userPack.Id = en.Id;
            userPack.PurchaseDate = (DateTime)en.PurchaseDate;
            userPack.Type = en.Type;
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