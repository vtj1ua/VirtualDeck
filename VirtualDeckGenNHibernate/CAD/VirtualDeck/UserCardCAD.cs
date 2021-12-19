
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
 * Clase UserCard:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class UserCardCAD : BasicCAD, IUserCardCAD
{
public UserCardCAD() : base ()
{
}

public UserCardCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserCardEN ReadOIDDefault (int id
                                  )
{
        UserCardEN userCardEN = null;

        try
        {
                SessionInitializeTransaction ();
                userCardEN = (UserCardEN)session.Get (typeof(UserCardEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userCardEN;
}

public System.Collections.Generic.IList<UserCardEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UserCardEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UserCardEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UserCardEN>();
                        else
                                result = session.CreateCriteria (typeof(UserCardEN)).List<UserCardEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UserCardEN userCard)
{
        try
        {
                SessionInitializeTransaction ();
                UserCardEN userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), userCard.Id);

                userCardEN.Type = userCard.Type;


                userCardEN.Rarity = userCard.Rarity;


                userCardEN.Speed = userCard.Speed;


                userCardEN.Defense = userCard.Defense;


                userCardEN.Attack = userCard.Attack;


                userCardEN.Health = userCard.Health;


                userCardEN.Level = userCard.Level;


                userCardEN.Experience = userCard.Experience;


                userCardEN.Name = userCard.Name;


                userCardEN.Img = userCard.Img;


                userCardEN.PurchaseDate = userCard.PurchaseDate;









                userCardEN.Quality = userCard.Quality;

                session.Update (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UserCardEN userCard)
{
        try
        {
                SessionInitializeTransaction ();
                if (userCard.AttackMoves != null) {
                        for (int i = 0; i < userCard.AttackMoves.Count; i++) {
                                userCard.AttackMoves [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN), userCard.AttackMoves [i].Id);
                                userCard.AttackMoves [i].UserCards.Add (userCard);
                        }
                }
                if (userCard.Card != null) {
                        // Argumento OID y no colección.
                        userCard.Card = (VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN), userCard.Card.Id);

                        userCard.Card.UserCards
                        .Add (userCard);
                }

                session.Save (userCard);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userCard.Id;
}

public void Modify (UserCardEN userCard)
{
        try
        {
                SessionInitializeTransaction ();
                UserCardEN userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), userCard.Id);

                userCardEN.Type = userCard.Type;


                userCardEN.Rarity = userCard.Rarity;


                userCardEN.Speed = userCard.Speed;


                userCardEN.Defense = userCard.Defense;


                userCardEN.Attack = userCard.Attack;


                userCardEN.Health = userCard.Health;


                userCardEN.Level = userCard.Level;


                userCardEN.Experience = userCard.Experience;


                userCardEN.Name = userCard.Name;


                userCardEN.Img = userCard.Img;


                userCardEN.PurchaseDate = userCard.PurchaseDate;


                userCardEN.Quality = userCard.Quality;

                session.Update (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DestroyCard (int id
                         )
{
        try
        {
                SessionInitializeTransaction ();
                UserCardEN userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), id);
                session.Delete (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UserCardEN
public UserCardEN ReadOID (int id
                           )
{
        UserCardEN userCardEN = null;

        try
        {
                SessionInitializeTransaction ();
                userCardEN = (UserCardEN)session.Get (typeof(UserCardEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userCardEN;
}

public System.Collections.Generic.IList<UserCardEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserCardEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UserCardEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UserCardEN>();
                else
                        result = session.CreateCriteria (typeof(UserCardEN)).List<UserCardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByName (int p_user, string p_name)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserCardEN self where FROM UserCardEN as uc WHERE uc.User.Id = :p_user AND uc.Name LIKE :p_name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserCardENuserCardsByNameHQL");
                query.SetParameter ("p_user", p_user);
                query.SetParameter ("p_name", p_name);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByBaseCard (int p_user, int p_baseCard)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserCardEN self where FROM UserCardEN as uc WHERE uc.User.Id = :p_user AND uc.Card.Id = :p_baseCard";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserCardENuserCardsByBaseCardHQL");
                query.SetParameter ("p_user", p_user);
                query.SetParameter ("p_baseCard", p_baseCard);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AssignUser (int p_UserCard_OID, int p_user_OID)
{
        VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN userCardEN = null;
        try
        {
                SessionInitializeTransaction ();
                userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), p_UserCard_OID);
                userCardEN.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), p_user_OID);

                userCardEN.User.UserCards.Add (userCardEN);



                session.Update (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DessasignUser (int p_UserCard_OID, int p_user_OID)
{
        try
        {
                SessionInitializeTransaction ();
                VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN userCardEN = null;
                userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), p_UserCard_OID);

                if (userCardEN.User.Id == p_user_OID) {
                        userCardEN.User = null;
                }
                else
                        throw new ModelException ("The identifier " + p_user_OID + " in p_user_OID you are trying to unrelationer, doesn't exist in UserCardEN");

                session.Update (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AssignPack (int p_UserCard_OID, int p_userPack_OID)
{
        VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN userCardEN = null;
        try
        {
                SessionInitializeTransaction ();
                userCardEN = (UserCardEN)session.Load (typeof(UserCardEN), p_UserCard_OID);
                userCardEN.UserPack = (VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN), p_userPack_OID);

                userCardEN.UserPack.UserCards.Add (userCardEN);



                session.Update (userCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByUser (int p_user)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserCardEN self where FROM UserCardEN as card where card.User.Id = :p_user";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserCardENuserCardsByUserHQL");
                query.SetParameter ("p_user", p_user);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsNotInTradeByUser (int p_user)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserCardEN self where FROM UserCardEN as card where card.User.Id = :p_user and card not in (select OfferedUserCard from TradeOffEN as trade where trade.State  = 1) ORDER BY card.Rarity ASC, card.Type ASC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserCardENuserCardsNotInTradeByUserHQL");
                query.SetParameter ("p_user", p_user);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
