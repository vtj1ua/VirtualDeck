using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class NotificationAssembler
    {
        public NotificationViewModel ConvertENToModelUI(NotificationEN en)
        {
            NotificationViewModel notif = new NotificationViewModel();
            notif.Id = en.Id;
            notif.Type = en.Type;
            return notif;


        }
        public IList<NotificationViewModel> ConvertListENToModel(IList<NotificationEN> ens)
        {
            IList<NotificationViewModel> notifs = new List<NotificationViewModel>();
            foreach (NotificationEN en in ens)
            {
                notifs.Add(ConvertENToModelUI(en));
            }
            return notifs;
        }
    }
}