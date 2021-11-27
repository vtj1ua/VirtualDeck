
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_TradeOff_publish) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class TradeOffCEN
{
public int Publish (int p_owner, int p_desiredCard, int p_offeredUserCard)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_TradeOff_publish_customized) ENABLED START*/

        TradeOffEN tradeOffEN = null;

        int oid;

        //Initialized TradeOffEN
        tradeOffEN = new TradeOffEN ();

        if (p_owner != -1) {
                tradeOffEN.Owner = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                tradeOffEN.Owner.Id = p_owner;
        }


        if (p_desiredCard != -1) {
                tradeOffEN.DesiredCard = new VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN ();
                tradeOffEN.DesiredCard.Id = p_desiredCard;
        }


        if (p_offeredUserCard != -1) {
                tradeOffEN.OfferedUserCard = new VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN ();
                tradeOffEN.OfferedUserCard.Id = p_offeredUserCard;
        }

        tradeOffEN.Date = DateTime.Now;
        tradeOffEN.State = TradeStateEnum.Pending;

        //Call to TradeOffCAD

        oid = _ITradeOffCAD.Publish (tradeOffEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
