

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class TradeOffCEN
 *
 */
public partial class TradeOffCEN
{
private ITradeOffCAD _ITradeOffCAD;

public TradeOffCEN()
{
        this._ITradeOffCAD = new TradeOffCAD ();
}

public TradeOffCEN(ITradeOffCAD _ITradeOffCAD)
{
        this._ITradeOffCAD = _ITradeOffCAD;
}

public ITradeOffCAD get_ITradeOffCAD ()
{
        return this._ITradeOffCAD;
}

public void Modify (int p_TradeOff_OID, Nullable<DateTime> p_date, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TradeStateEnum p_state)
{
        TradeOffEN tradeOffEN = null;

        //Initialized TradeOffEN
        tradeOffEN = new TradeOffEN ();
        tradeOffEN.Id = p_TradeOff_OID;
        tradeOffEN.Date = p_date;
        tradeOffEN.State = p_state;
        //Call to TradeOffCAD

        _ITradeOffCAD.Modify (tradeOffEN);
}

public void Destroy (int id
                     )
{
        _ITradeOffCAD.Destroy (id);
}

public TradeOffEN ReadOID (int id
                           )
{
        TradeOffEN tradeOffEN = null;

        tradeOffEN = _ITradeOffCAD.ReadOID (id);
        return tradeOffEN;
}

public System.Collections.Generic.IList<TradeOffEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TradeOffEN> list = null;

        list = _ITradeOffCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradesByCardName (string p_cardName)
{
        return _ITradeOffCAD.TradesByCardName (p_cardName);
}
}
}
