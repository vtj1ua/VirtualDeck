
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Notification_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class NotificationCP : BasicCP
{
public VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN New_ (int p_user, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum p_type)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Notification_new_) ENABLED START*/

        INotificationCAD notificationCAD = null;
        NotificationCEN notificationCEN = null;

        VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN result = null;


        try
        {
                SessionInitializeTransaction ();
                notificationCAD = new NotificationCAD (session);
                notificationCEN = new  NotificationCEN (notificationCAD);




                int oid;
                //Initialized NotificationEN
                NotificationEN notificationEN;
                notificationEN = new NotificationEN ();

                if (p_user != -1) {
                        notificationEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                        notificationEN.User.Id = p_user;
                }

                notificationEN.Type = p_type;

                //Call to NotificationCAD

                oid = notificationCAD.New_ (notificationEN);
                result = notificationCAD.ReadOIDDefault (oid);

                //Obtener el usuario desde aqui y enviarle el correo
                //(Metelo dentro de otro try-catch, que si crashea lo de enviar la notificacion no se crea
                try
                {

                }catch(Exception ex2)
                {

                }

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
