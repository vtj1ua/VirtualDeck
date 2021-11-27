
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface INotificationCAD
{
NotificationEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificationEN notification);

System.Collections.Generic.IList<NotificationEN> ReadAllDefault (int first, int size);



int New_ (NotificationEN notification);

void Modify (NotificationEN notification);


void Destroy (int id
              );


NotificationEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificationEN> ReadAll (int first, int size);
}
}
