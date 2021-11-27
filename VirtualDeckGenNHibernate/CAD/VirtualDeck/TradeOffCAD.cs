
using System;
using System.Text;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.Exceptions;


/*
 * Clase TradeOff:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class TradeOffCAD : BasicCAD, ITradeOffCAD
{
public TradeOffCAD() : base ()
{
}

public TradeOffCAD(ISession sessionAux) : base (sessionAux)
{
}



public TradeOffEN ReadOIDDefault (int id
                                  )
{
        TradeOffEN tradeOffEN = null;

        try
        {
                SessionInitializeTransaction ();
                tradeOffEN = (TradeOffEN)session.Get (typeof(TradeOffEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tradeOffEN;
}

public System.Collections.Generic.IList<TradeOffEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TradeOffEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TradeOffEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TradeOffEN>();
                        else
                                result = session.CreateCriteria (typeof(TradeOffEN)).List<TradeOffEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TradeOffEN tradeOff)
{
        try
        {
                SessionInitializeTransaction ();
                TradeOffEN tradeOffEN = (TradeOffEN)session.Load (typeof(TradeOffEN), tradeOff.Id);

                tradeOffEN.Date = tradeOff.Date;





                tradeOffEN.State = tradeOff.State;




                session.Update (tradeOffEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (TradeOffEN tradeOff)
{
        try
        {
                SessionInitializeTransaction ();
                TradeOffEN tradeOffEN = (TradeOffEN)session.Load (typeof(TradeOffEN), tradeOff.Id);

                tradeOffEN.Date = tradeOff.Date;


                tradeOffEN.State = tradeOff.State;

                session.Update (tradeOffEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                TradeOffEN tradeOffEN = (TradeOffEN)session.Load (typeof(TradeOffEN), id);
                session.Delete (tradeOffEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TradeOffEN
public TradeOffEN ReadOID (int id
                           )
{
        TradeOffEN tradeOffEN = null;

        try
        {
                SessionInitializeTransaction ();
                tradeOffEN = (TradeOffEN)session.Get (typeof(TradeOffEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tradeOffEN;
}

public System.Collections.Generic.IList<TradeOffEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TradeOffEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TradeOffEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TradeOffEN>();
                else
                        result = session.CreateCriteria (typeof(TradeOffEN)).List<TradeOffEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradesByCardName (string p_cardName)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TradeOffEN self where FROM TradeOffEN as trade WHERE trade.OfferedUserCard.Name LIKE :p_cardName OR trade.DesiredCard.Name LIKE :p_cardName";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TradeOffENtradesByCardNameHQL");
                query.SetParameter ("p_cardName", p_cardName);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Publish (TradeOffEN tradeOff)
{
        try
        {
                SessionInitializeTransaction ();
                if (tradeOff.Owner != null) {
                        // Argumento OID y no colección.
                        tradeOff.Owner = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), tradeOff.Owner.Id);

                        tradeOff.Owner.PublishedTradeOffs
                        .Add (tradeOff);
                }
                if (tradeOff.DesiredCard != null) {
                        // Argumento OID y no colección.
                        tradeOff.DesiredCard = (VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN), tradeOff.DesiredCard.Id);

                        tradeOff.DesiredCard.TradeOffs
                        .Add (tradeOff);
                }
                if (tradeOff.OfferedUserCard != null) {
                        // Argumento OID y no colección.
                        tradeOff.OfferedUserCard = (VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN), tradeOff.OfferedUserCard.Id);

                        tradeOff.OfferedUserCard.OfferedTradeOffs
                        .Add (tradeOff);
                }

                session.Save (tradeOff);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TradeOffCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tradeOff.Id;
}
}
}
