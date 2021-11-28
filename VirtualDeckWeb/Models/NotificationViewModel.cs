using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public TypeNotificationEnum Type { get; set; }
    }
}