
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
 * Clase UserPack:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class UserPackCAD : BasicCAD, IUserPackCAD
{
public UserPackCAD() : base ()
{
}

public UserPackCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserPackEN ReadOIDDefault (int id
                                  )
{
        UserPackEN userPackEN = null;

        try
        {
                SessionInitializeTransaction ();
                userPackEN = (UserPackEN)session.Get (typeof(UserPackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userPackEN;
}

public System.Collections.Generic.IList<UserPackEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UserPackEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UserPackEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UserPackEN>();
                        else
                                result = session.CreateCriteria (typeof(UserPackEN)).List<UserPackEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UserPackEN userPack)
{
        try
        {
                SessionInitializeTransaction ();
                UserPackEN userPackEN = (UserPackEN)session.Load (typeof(UserPackEN), userPack.Id);

                userPackEN.PurchaseDate = userPack.PurchaseDate;


                userPackEN.Rarity = userPack.Rarity;





                userPackEN.Name = userPack.Name;

                session.Update (userPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UserPackEN userPack)
{
        try
        {
                SessionInitializeTransaction ();
                if (userPack.User != null) {
                        // Argumento OID y no colección.
                        userPack.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), userPack.User.Id);

                        userPack.User.UserPacks
                        .Add (userPack);
                }
                if (userPack.UserCards != null) {
                        foreach (VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN item in userPack.UserCards) {
                                item.UserPack = userPack;
                                session.Save (item);
                        }
                }
                if (userPack.Pack != null) {
                        // Argumento OID y no colección.
                        userPack.Pack = (VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN), userPack.Pack.Id);

                        userPack.Pack.UserPacks
                        .Add (userPack);
                }

                session.Save (userPack);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userPack.Id;
}

public void Modify (UserPackEN userPack)
{
        try
        {
                SessionInitializeTransaction ();
                UserPackEN userPackEN = (UserPackEN)session.Load (typeof(UserPackEN), userPack.Id);

                userPackEN.PurchaseDate = userPack.PurchaseDate;


                userPackEN.Rarity = userPack.Rarity;


                userPackEN.Name = userPack.Name;

                session.Update (userPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
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
                UserPackEN userPackEN = (UserPackEN)session.Load (typeof(UserPackEN), id);
                session.Delete (userPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void OpenPack (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                UserPackEN userPackEN = (UserPackEN)session.Load (typeof(UserPackEN), id);
                session.Delete (userPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UserPackEN
public UserPackEN ReadOID (int id
                           )
{
        UserPackEN userPackEN = null;

        try
        {
                SessionInitializeTransaction ();
                userPackEN = (UserPackEN)session.Get (typeof(UserPackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userPackEN;
}

public System.Collections.Generic.IList<UserPackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserPackEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UserPackEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UserPackEN>();
                else
                        result = session.CreateCriteria (typeof(UserPackEN)).List<UserPackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacksByUser (int p_user)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UserPackEN self where FROM UserPackEN as pack where pack.User.Id = :p_user";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UserPackENuserPacksByUserHQL");
                query.SetParameter ("p_user", p_user);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in UserPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
