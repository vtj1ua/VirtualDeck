
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Pack_createAndPurchaseUserPack) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class PackCP : BasicCP
{
public void CreateAndPurchaseUserPack (int p_oid, int p_userId)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Pack_createAndPurchaseUserPack) ENABLED START*/

        IPackCAD packCAD = null;
        PackCEN packCEN = null;



        try
        {
                SessionInitializeTransaction ();
                packCAD = new PackCAD (session);
                packCEN = new  PackCEN (packCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CreateAndPurchaseUserPack() not yet implemented.");



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
