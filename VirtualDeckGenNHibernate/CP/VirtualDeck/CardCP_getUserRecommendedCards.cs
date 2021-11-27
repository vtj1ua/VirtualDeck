
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Card_getUserRecommendedCards) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CardCP : BasicCP
{
public void GetUserRecommendedCards (int p_userId)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Card_getUserRecommendedCards) ENABLED START*/

        ICardCAD cardCAD = null;
        CardCEN cardCEN = null;



        try
        {
                SessionInitializeTransaction ();
                cardCAD = new CardCAD (session);
                cardCEN = new  CardCEN (cardCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method GetUserRecommendedCards() not yet implemented.");



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
