
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
 * Clase Pack:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class PackCAD : BasicCAD, IPackCAD
{
public PackCAD() : base ()
{
}

public PackCAD(ISession sessionAux) : base (sessionAux)
{
}



public PackEN ReadOIDDefault (int id
                              )
{
        PackEN packEN = null;

        try
        {
                SessionInitializeTransaction ();
                packEN = (PackEN)session.Get (typeof(PackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return packEN;
}

public System.Collections.Generic.IList<PackEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PackEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PackEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PackEN>();
                        else
                                result = session.CreateCriteria (typeof(PackEN)).List<PackEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PackEN pack)
{
        try
        {
                SessionInitializeTransaction ();
                PackEN packEN = (PackEN)session.Load (typeof(PackEN), pack.Id);

                packEN.Type = pack.Type;


                packEN.MaxNumCards = pack.MaxNumCards;



                packEN.MinNumCards = pack.MinNumCards;

                session.Update (packEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PackEN pack)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pack);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pack.Id;
}

public void Modify (PackEN pack)
{
        try
        {
                SessionInitializeTransaction ();
                PackEN packEN = (PackEN)session.Load (typeof(PackEN), pack.Id);

                packEN.Name = pack.Name;


                packEN.Description = pack.Description;


                packEN.Price = pack.Price;


                packEN.Img = pack.Img;


                packEN.Type = pack.Type;


                packEN.MaxNumCards = pack.MaxNumCards;


                packEN.MinNumCards = pack.MinNumCards;

                session.Update (packEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
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
                PackEN packEN = (PackEN)session.Load (typeof(PackEN), id);
                session.Delete (packEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PackEN
public PackEN ReadOID (int id
                       )
{
        PackEN packEN = null;

        try
        {
                SessionInitializeTransaction ();
                packEN = (PackEN)session.Get (typeof(PackEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return packEN;
}

public System.Collections.Generic.IList<PackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PackEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PackEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PackEN>();
                else
                        result = session.CreateCriteria (typeof(PackEN)).List<PackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByType (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum ? p_type)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PackEN self where  FROM PackEN as pack where pack.Type=:p_type";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PackENpacksByTypeHQL");
                query.SetParameter ("p_type", p_type);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByNameOrDescription (string p_name)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PackEN self where FROM PackEN as pack where pack.Name like :p_name or pack.Description like :p_name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PackENpacksByNameOrDescriptionHQL");
                query.SetParameter ("p_name", p_name);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in PackCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
