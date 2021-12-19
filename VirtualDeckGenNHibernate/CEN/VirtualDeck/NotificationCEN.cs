

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class NotificationCEN
 *
 */
public partial class NotificationCEN
{
private INotificationCAD _INotificationCAD;

public NotificationCEN()
{
        this._INotificationCAD = new NotificationCAD ();
}

public NotificationCEN(INotificationCAD _INotificationCAD)
{
        this._INotificationCAD = _INotificationCAD;
}

public INotificationCAD get_INotificationCAD ()
{
        return this._INotificationCAD;
}

public void Modify (int p_Notification_OID, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum p_type)
{
        NotificationEN notificationEN = null;

        //Initialized NotificationEN
        notificationEN = new NotificationEN ();
        notificationEN.Id = p_Notification_OID;
        notificationEN.Type = p_type;
        //Call to NotificationCAD

        _INotificationCAD.Modify (notificationEN);
}

public void Destroy (int id
                     )
{
        _INotificationCAD.Destroy (id);
}

public NotificationEN ReadOID (int id
                               )
{
        NotificationEN notificationEN = null;

        notificationEN = _INotificationCAD.ReadOID (id);
        return notificationEN;
}

public System.Collections.Generic.IList<NotificationEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificationEN> list = null;

        list = _INotificationCAD.ReadAll (first, size);
        return list;
}
}
}
