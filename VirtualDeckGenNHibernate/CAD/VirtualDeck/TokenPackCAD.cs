
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
 * Clase TokenPack:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class TokenPackCAD : BasicCAD, ITokenPackCAD
{
public TokenPackCAD() : base ()
{
}

public TokenPackCAD(ISession sessionAux) : base (sessionAux)
{
}



public TokenPackEN ReadOIDDefault (int id
                                   )
{
        TokenPackEN tokenPackEN = null;

        try
        {
                SessionInitializeTransaction ();
                tokenPackEN = (TokenPackEN)session.Get (typeof(TokenPackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tokenPackEN;
}

public System.Collections.Generic.IList<TokenPackEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TokenPackEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TokenPackEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TokenPackEN>();
                        else
                                result = session.CreateCriteria (typeof(TokenPackEN)).List<TokenPackEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TokenPackEN tokenPack)
{
        try
        {
                SessionInitializeTransaction ();
                TokenPackEN tokenPackEN = (TokenPackEN)session.Load (typeof(TokenPackEN), tokenPack.Id);

                tokenPackEN.Name = tokenPack.Name;


                tokenPackEN.Price = tokenPack.Price;



                tokenPackEN.Tokens = tokenPack.Tokens;

                session.Update (tokenPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (TokenPackEN tokenPack)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tokenPack);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tokenPack.Id;
}

public void Modify (TokenPackEN tokenPack)
{
        try
        {
                SessionInitializeTransaction ();
                TokenPackEN tokenPackEN = (TokenPackEN)session.Load (typeof(TokenPackEN), tokenPack.Id);

                tokenPackEN.Name = tokenPack.Name;


                tokenPackEN.Price = tokenPack.Price;


                tokenPackEN.Tokens = tokenPack.Tokens;

                session.Update (tokenPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
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
                TokenPackEN tokenPackEN = (TokenPackEN)session.Load (typeof(TokenPackEN), id);
                session.Delete (tokenPackEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TokenPackEN
public TokenPackEN ReadOID (int id
                            )
{
        TokenPackEN tokenPackEN = null;

        try
        {
                SessionInitializeTransaction ();
                tokenPackEN = (TokenPackEN)session.Get (typeof(TokenPackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tokenPackEN;
}

public System.Collections.Generic.IList<TokenPackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TokenPackEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TokenPackEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TokenPackEN>();
                else
                        result = session.CreateCriteria (typeof(TokenPackEN)).List<TokenPackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in TokenPackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
