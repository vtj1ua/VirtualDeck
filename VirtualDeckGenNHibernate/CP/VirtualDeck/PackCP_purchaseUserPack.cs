
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Pack_purchaseUserPack) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class PackCP : BasicCP
{
public System.Collections.Generic.IList<int> PurchaseUserPack (int p_pack, int p_user, int p_amount)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Pack_purchaseUserPack) ENABLED START*/
        List<int> userPacks = new List<int>();
        IPackCAD packCAD = null;
        PackCEN packCEN = null;
        Random rnd = new Random ();

        try
        {
                SessionInitializeTransaction ();
                packCAD = new PackCAD (session);
                packCEN = new PackCEN (packCAD);

                VirtualUserCAD virtualUserCAD = new VirtualUserCAD (session);
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN (virtualUserCAD);

                BillCP billCP = new BillCP(session);

                PackCP packCP = new PackCP (session);

                PackEN packEN = packCEN.ReadOID (p_pack);
                VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID (p_user);

                int totalPrice = packEN.Price * p_amount;

                if (virtualUserEN.Tokens < totalPrice) {
                        throw new InvalidOperationException ("El usuario no tiene suficientes tokens.");
                }

                //Crear factura
                billCP.CreateAssociateProduct (p_user, p_pack, p_amount);

                //Crear los sobres y asignarlos
                for (int i = 0; i < p_amount; ++i) {
                        userPacks.Add (packCP.CreateUserPack (p_pack, p_user, rnd.Next ()));
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
        return userPacks;

        /*PROTECTED REGION END*/
}
}
}
