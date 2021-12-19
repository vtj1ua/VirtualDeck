
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
 * Clase Card:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class CardCAD : BasicCAD, ICardCAD
{
public CardCAD() : base ()
{
}

public CardCAD(ISession sessionAux) : base (sessionAux)
{
}



public CardEN ReadOIDDefault (int id
                              )
{
        CardEN cardEN = null;

        try
        {
                SessionInitializeTransaction ();
                cardEN = (CardEN)session.Get (typeof(CardEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cardEN;
}

public System.Collections.Generic.IList<CardEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CardEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CardEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CardEN>();
                        else
                                result = session.CreateCriteria (typeof(CardEN)).List<CardEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CardEN card)
{
        try
        {
                SessionInitializeTransaction ();
                CardEN cardEN = (CardEN)session.Load (typeof(CardEN), card.Id);

                cardEN.Type = card.Type;


                cardEN.Health = card.Health;


                cardEN.Attack = card.Attack;


                cardEN.Defense = card.Defense;


                cardEN.Speed = card.Speed;


                cardEN.Rarity = card.Rarity;




                session.Update (cardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CardEN card)
{
        try
        {
                SessionInitializeTransaction ();
                if (card.AttackMoves != null) {
                        for (int i = 0; i < card.AttackMoves.Count; i++) {
                                card.AttackMoves [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN), card.AttackMoves [i].Id);
                                card.AttackMoves [i].Cards.Add (card);
                        }
                }

                session.Save (card);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return card.Id;
}

public void Modify (CardEN card)
{
        try
        {
                SessionInitializeTransaction ();
                CardEN cardEN = (CardEN)session.Load (typeof(CardEN), card.Id);

                cardEN.Name = card.Name;


                cardEN.Description = card.Description;


                cardEN.Price = card.Price;


                cardEN.Img = card.Img;


                cardEN.RegistryDate = card.RegistryDate;


                cardEN.Type = card.Type;


                cardEN.Health = card.Health;


                cardEN.Attack = card.Attack;


                cardEN.Defense = card.Defense;


                cardEN.Speed = card.Speed;


                cardEN.Rarity = card.Rarity;

                session.Update (cardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
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
                CardEN cardEN = (CardEN)session.Load (typeof(CardEN), id);
                session.Delete (cardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CardEN
public CardEN ReadOID (int id
                       )
{
        CardEN cardEN = null;

        try
        {
                SessionInitializeTransaction ();
                cardEN = (CardEN)session.Get (typeof(CardEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cardEN;
}

public System.Collections.Generic.IList<CardEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CardEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CardEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CardEN>();
                else
                        result = session.CreateCriteria (typeof(CardEN)).List<CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByType (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum ? p_type)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card where (card.Type & :p_type) != 0";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByTypeHQL");
                query.SetParameter ("p_type", p_type);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card where  (card.Rarity & :p_rarity) != 0";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByRarityHQL");
                query.SetParameter ("p_rarity", p_rarity);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByNameOrDescription (string p_cardName)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card where card.Description like :p_cardName or card.Name like :p_cardName";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByNameOrDescriptionHQL");
                query.SetParameter ("p_cardName", p_cardName);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByPrice (int? p_min_price, int ? p_max_price)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card where card.Price >= :p_min_price AND card.Price <= :p_max_price";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByPriceHQL");
                query.SetParameter ("p_min_price", p_min_price);
                query.SetParameter ("p_max_price", p_max_price);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByMaxRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card where card.Rarity <= :p_rarity";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByMaxRarityHQL");
                query.SetParameter ("p_rarity", p_rarity);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByTypeAndRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum? p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card WHERE (card.Type & :p_type) != 0 AND (card.Rarity & :p_rarity) != 0 ORDER BY card.Rarity ASC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByTypeAndRarityHQL");
                query.SetParameter ("p_type", p_type);
                query.SetParameter ("p_rarity", p_rarity);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRegistryDate ()
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card ORDER BY card.RegistryDate DESC LIMIT 10";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByRegistryDateHQL");

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByAllFilters (string p_name, int? p_min_price, int? p_max_price, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum? p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CardEN self where FROM CardEN as card WHERE (card.Description LIKE :p_name OR  card.Name LIKE :p_name) AND card.Price >= :p_min_price AND card.Price <= :p_max_price AND (card.Type & :p_type) != 0 AND (card.Rarity & :p_rarity) != 0 ORDER BY card.Rarity ASC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CardENcardsByAllFiltersHQL");
                query.SetParameter ("p_name", p_name);
                query.SetParameter ("p_min_price", p_min_price);
                query.SetParameter ("p_max_price", p_max_price);
                query.SetParameter ("p_type", p_type);
                query.SetParameter ("p_rarity", p_rarity);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
