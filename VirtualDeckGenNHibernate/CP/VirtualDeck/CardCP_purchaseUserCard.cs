
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Card_purchaseUserCard) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CardCP : BasicCP
{
public void PurchaseUserCard (int p_card, int p_user, int p_amount)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Card_purchaseUserCard) ENABLED START*/

        ICardCAD cardCAD = null;
        CardCEN cardCEN = null;
        Random rnd = new Random ();


        try
        {
                SessionInitializeTransaction ();
                cardCAD = new CardCAD (session);
                cardCEN = new CardCEN (cardCAD);

                VirtualUserCAD virtualUserCAD = new VirtualUserCAD (session);
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN (virtualUserCAD);

                UserCardCAD userCardCAD = new UserCardCAD (session);
                UserCardCEN userCardCEN = new UserCardCEN (userCardCAD);

                BillCP billCP = new BillCP (session);

                CardCP cardCP = new CardCP (session);

                CardEN cardEN = cardCEN.ReadOID (p_card);
                VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID (p_user);

                int totalPrice = cardEN.Price * p_amount;

                if (virtualUserEN.Tokens < totalPrice) {
                        throw new InvalidOperationException ("El usuario no tiene suficientes tokens.");
                }

                //Crear factura
                billCP.CreateAssociateProduct (p_user, p_card, p_amount);

                //Crear las cartas y asignarselas
                for (int i = 0; i < p_amount; ++i) {
                        int cardId = cardCP.CreateUserCard (p_card, rnd.Next ());

                        userCardCEN.AssignUser (cardId, p_user);
                }

                //Restarle los tokens al usuario
                virtualUserEN.Tokens -= totalPrice;
                virtualUserCAD.ModifyDefault (virtualUserEN);

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
