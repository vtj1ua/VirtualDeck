
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_TradeOff_trade) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class TradeOffCP : BasicCP
{
public void Trade (int p_oid, int p_givenUserCard)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_TradeOff_trade) ENABLED START*/
        ITradeOffCAD tradeOffCAD = null;
        TradeOffCEN tradeOffCEN = null;
        UserCardCAD userCardCAD = null;
        UserCardCEN userCardCEN = null;
        NotificationCAD notificationCAD = null;
        NotificationCEN notificationCEN = null;
        NotificationCP notificationCP = null;

        try
        {
                SessionInitializeTransaction ();
                tradeOffCAD = new TradeOffCAD (session);
                tradeOffCEN = new TradeOffCEN (tradeOffCAD);
                TradeOffEN tradeOffEN = tradeOffCEN.ReadOID (p_oid);

                userCardCAD = new UserCardCAD (session);
                userCardCEN = new UserCardCEN (userCardCAD);
                UserCardEN userCardEN = userCardCEN.ReadOID (p_givenUserCard);

                notificationCAD = new NotificationCAD (session);
                notificationCEN = new NotificationCEN (notificationCAD);
                notificationCP = new NotificationCP(session);

                //asigno al intercambio el exchanger
                tradeOffCEN.AssignExchanger (p_oid, userCardEN.User.Id);

                if (userCardEN.Card.Id.Equals (tradeOffEN.DesiredCard.Id)) {
                        tradeOffEN.State = TradeStateEnum.Accepted;

                        //creo la notificacion, le asigno el segundo usuario y la asigno al trade.
                        NotificationEN idNotification1 = notificationCP.New_ (tradeOffEN.Exchanger.Id, TypeNotificationEnum.TradeDone);
                        NotificationEN idNotification2 = notificationCP.New_ (tradeOffEN.Owner.Id, TypeNotificationEnum.TradeDone);

                        tradeOffCEN.AssignNotification (p_oid, new List<int>() {
                                        idNotification1.Id, idNotification2.Id
                                });


                        userCardCEN.DessasignUser (p_givenUserCard, tradeOffEN.Exchanger.Id);
                        userCardCEN.DessasignUser (tradeOffEN.OfferedUserCard.Id, tradeOffEN.Owner.Id);

                        userCardCEN.AssignUser (p_givenUserCard, tradeOffEN.Owner.Id);
                        userCardCEN.AssignUser (tradeOffEN.OfferedUserCard.Id, tradeOffEN.Exchanger.Id);
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


        /*PROTECTED REGION END*/
}
}
}
