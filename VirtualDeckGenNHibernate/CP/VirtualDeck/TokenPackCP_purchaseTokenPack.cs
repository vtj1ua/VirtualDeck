
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_TokenPack_purchaseTokenPack) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class TokenPackCP : BasicCP
{
public void PurchaseTokenPack (int p_oid, int p_userId)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_TokenPack_purchaseTokenPack) ENABLED START*/
        ITokenPackCAD tokenPackCAD = null;
        TokenPackCEN tokenPackCEN = null;
        TokenPackEN tokenPackEN = null;
        IVirtualUserCAD virtualUserCAD = null;
        VirtualUserCEN virtualUserCEN = null;
        VirtualUserEN virtualUserEN = null;
        BillCP billCP = null;
        INotificationCAD notificationCAD = null;
        NotificationCEN notificationCEN = null;

        try
        {
                SessionInitializeTransaction ();
                tokenPackCAD = new TokenPackCAD (session);
                tokenPackCEN = new TokenPackCEN (tokenPackCAD);
                tokenPackEN = tokenPackCEN.ReadOID (p_oid);

                virtualUserCAD = new VirtualUserCAD (session);
                virtualUserCEN = new VirtualUserCEN (virtualUserCAD);
                virtualUserEN = virtualUserCEN.ReadOID (p_userId);
                virtualUserEN.Tokens += tokenPackEN.Tokens;
                virtualUserCAD.ModifyDefault (virtualUserEN);

                //falta crear factura y notificacion

                BillCAD billCAD = new BillCAD (session);
                BillCEN billCEN = new BillCEN (billCAD);
                billCEN.CreateAssociateToken (p_userId, p_oid);

                notificationCAD = new NotificationCAD (session);
                notificationCEN = new NotificationCEN (notificationCAD);
                notificationCEN.New_ (p_userId, TypeNotificationEnum.Bill);





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