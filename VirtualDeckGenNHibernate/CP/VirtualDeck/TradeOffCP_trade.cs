
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
//  references to other libraries
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



        try
        {
                SessionInitializeTransaction ();
                tradeOffCAD = new TradeOffCAD (session);
                tradeOffCEN = new  TradeOffCEN (tradeOffCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Trade() not yet implemented.");



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
