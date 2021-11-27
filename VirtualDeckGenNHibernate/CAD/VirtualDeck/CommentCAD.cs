
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
 * Clase Comment:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class CommentCAD : BasicCAD, ICommentCAD
{
public CommentCAD() : base ()
{
}

public CommentCAD(ISession sessionAux) : base (sessionAux)
{
}



public CommentEN ReadOIDDefault (int id
                                 )
{
        CommentEN commentEN = null;

        try
        {
                SessionInitializeTransaction ();
                commentEN = (CommentEN)session.Get (typeof(CommentEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return commentEN;
}

public System.Collections.Generic.IList<CommentEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CommentEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CommentEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CommentEN>();
                        else
                                result = session.CreateCriteria (typeof(CommentEN)).List<CommentEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CommentEN comment)
{
        try
        {
                SessionInitializeTransaction ();
                CommentEN commentEN = (CommentEN)session.Load (typeof(CommentEN), comment.Id);

                commentEN.Text = comment.Text;


                commentEN.PublishDate = comment.PublishDate;



                session.Update (commentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Publish (CommentEN comment)
{
        try
        {
                SessionInitializeTransaction ();
                if (comment.Product != null) {
                        // Argumento OID y no colección.
                        comment.Product = (VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN), comment.Product.Id);

                        comment.Product.Comments
                        .Add (comment);
                }
                if (comment.User != null) {
                        // Argumento OID y no colección.
                        comment.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), comment.User.Id);

                        comment.User.Comments
                        .Add (comment);
                }

                session.Save (comment);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comment.Id;
}

public void Modify (CommentEN comment)
{
        try
        {
                SessionInitializeTransaction ();
                CommentEN commentEN = (CommentEN)session.Load (typeof(CommentEN), comment.Id);

                commentEN.Text = comment.Text;


                commentEN.PublishDate = comment.PublishDate;

                session.Update (commentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
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
                CommentEN commentEN = (CommentEN)session.Load (typeof(CommentEN), id);
                session.Delete (commentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CommentEN
public CommentEN ReadOID (int id
                          )
{
        CommentEN commentEN = null;

        try
        {
                SessionInitializeTransaction ();
                commentEN = (CommentEN)session.Get (typeof(CommentEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return commentEN;
}

public System.Collections.Generic.IList<CommentEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CommentEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CommentEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CommentEN>();
                else
                        result = session.CreateCriteria (typeof(CommentEN)).List<CommentEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CommentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
