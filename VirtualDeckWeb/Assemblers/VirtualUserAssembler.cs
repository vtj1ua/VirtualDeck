using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class VirtualUserAssembler
    {
        public VirtualUserViewModel ConvertENToModelUI(VirtualUserEN en)
        {
            VirtualUserViewModel user = new VirtualUserViewModel();
            user.Id = en.Id;
            user.Pass = en.Pass;
            user.UserName = en.UserName;
            user.Email = en.Email;
            user.Description = en.Description;
            user.Tokens = en.Tokens;
            user.Img = en.Img;
            user.CombatStatus = (int)en.CombatStatus;
            user.NumCards = en.UserCards.Count;
            return user;


        }
        public IList<VirtualUserViewModel> ConvertListENToModel(IList<VirtualUserEN> ens)
        {
            IList<VirtualUserViewModel> users = new List<VirtualUserViewModel>();
            foreach (VirtualUserEN en in ens)
            {
                users.Add(ConvertENToModelUI(en));
            }
            return users;
        }
    }
}