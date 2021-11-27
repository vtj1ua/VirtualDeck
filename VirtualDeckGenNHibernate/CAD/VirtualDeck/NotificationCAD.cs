
using System;
using System.Text;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Exceptions;


/*
 * Clase Notification:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class NotificationCAD : BasicCAD, INotificationCAD
{
public NotificationCAD() : base ()
{
}

public NotificationCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificationEN ReadOIDDefault (int id
                                      )
{
        NotificationEN notificationEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificationEN = (NotificationEN)session.Get (typeof(NotificationEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificationEN;
}

public System.Collections.Generic.IList<NotificationEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificationEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificationEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificationEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificationEN)).List<NotificationEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificationEN notification)
{
        try
        {
                SessionInitializeTransaction ();
                NotificationEN notificationEN = (NotificationEN)session.Load (typeof(NotificationEN), notification.Id);



                notificationEN.Type = notification.Type;


                session.Update (notificationEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificationEN notification)
{
        try
        {
                SessionInitializeTransaction ();
                if (notification.User != null) {
                        // Argumento OID y no colección.
                        notification.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), notification.User.Id);

                        notification.User.Notifications
                        .Add (notification);
                }

                session.Save (notification);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notification.Id;
}

public void Modify (NotificationEN notification)
{
        try
        {
                SessionInitializeTransaction ();
                NotificationEN notificationEN = (NotificationEN)session.Load (typeof(NotificationEN), notification.Id);

                notificationEN.Type = notification.Type;

                session.Update (notificationEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificationEN notificationEN = (NotificationEN)session.Load (typeof(NotificationEN), id);
                session.Delete (notificationEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificationEN
public NotificationEN ReadOID (int id
                               )
{
        NotificationEN notificationEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificationEN = (NotificationEN)session.Get (typeof(NotificationEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificationEN;
}

public System.Collections.Generic.IList<NotificationEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificationEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificationEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificationEN>();
                else
                        result = session.CreateCriteria (typeof(NotificationEN)).List<NotificationEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in NotificationCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
