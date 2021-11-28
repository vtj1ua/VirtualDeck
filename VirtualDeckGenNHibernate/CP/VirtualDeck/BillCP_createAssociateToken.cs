
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




/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Bill_createAssociateToken) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class BillCP : BasicCP
{
public VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN CreateAssociateToken (int p_user, int p_tokenPack)
{
            /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Bill_createAssociateToken) ENABLED START*/

            IBillCAD billCAD = null;
            BillCEN billCEN = null;
            NotificationCAD notificationCAD = null;
            NotificationCEN notificationCEN = null;

            VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN result = null;


            try
            {
                SessionInitializeTransaction();
                billCAD = new BillCAD(session);
                billCEN = new BillCEN(billCAD);

                notificationCAD = new NotificationCAD(session);
                notificationCEN = new NotificationCEN(notificationCAD);


                int oid;
                //Initialized BillEN
                BillEN billEN;
                billEN = new BillEN();

                billEN.Date = DateTime.Now;
                billEN.Amount = 1;


                if (p_user != -1)
                {
                    billEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN();
                    billEN.User.Id = p_user;
                }
                if (p_tokenPack != -1)
                {
                    billEN.TokenPack = new VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN();
                    billEN.TokenPack.Id = p_tokenPack;
                }


                int idNotification = notificationCEN.New_(p_user, TypeNotificationEnum.Bill);


                oid = billCAD.CreateAssociateToken(billEN);
                billCEN.AssignNotification(oid, idNotification);
                result = billCAD.ReadOIDDefault(oid);



                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
            return result;


            /*PROTECTED REGION END*/
        }
}
}
