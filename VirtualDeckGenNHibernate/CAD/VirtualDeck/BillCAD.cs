
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
 * Clase Bill:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class BillCAD : BasicCAD, IBillCAD
{
public BillCAD() : base ()
{
}

public BillCAD(ISession sessionAux) : base (sessionAux)
{
}



public BillEN ReadOIDDefault (int id
                              )
{
        BillEN billEN = null;

        try
        {
                SessionInitializeTransaction ();
                billEN = (BillEN)session.Get (typeof(BillEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return billEN;
}

public System.Collections.Generic.IList<BillEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BillEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BillEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<BillEN>();
                        else
                                result = session.CreateCriteria (typeof(BillEN)).List<BillEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (BillEN bill)
{
        try
        {
                SessionInitializeTransaction ();
                BillEN billEN = (BillEN)session.Load (typeof(BillEN), bill.Id);

                billEN.Date = bill.Date;




                billEN.Amount = bill.Amount;



                session.Update (billEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (BillEN bill)
{
        try
        {
                SessionInitializeTransaction ();
                BillEN billEN = (BillEN)session.Load (typeof(BillEN), bill.Id);

                billEN.Date = bill.Date;


                billEN.Amount = bill.Amount;

                session.Update (billEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
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
                BillEN billEN = (BillEN)session.Load (typeof(BillEN), id);
                session.Delete (billEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int CreateAssociateToken (BillEN bill)
{
        try
        {
                SessionInitializeTransaction ();
                if (bill.User != null) {
                        // Argumento OID y no colección.
                        bill.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), bill.User.Id);

                        bill.User.Bills
                        .Add (bill);
                }
                if (bill.TokenPack != null) {
                        // Argumento OID y no colección.
                        bill.TokenPack = (VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN), bill.TokenPack.Id);

                        bill.TokenPack.Bills
                        .Add (bill);
                }

                session.Save (bill);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bill.Id;
}

public int CreateAssociateProduct (BillEN bill)
{
        try
        {
                SessionInitializeTransaction ();
                if (bill.User != null) {
                        // Argumento OID y no colección.
                        bill.User = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), bill.User.Id);

                        bill.User.Bills
                        .Add (bill);
                }
                if (bill.Product != null) {
                        // Argumento OID y no colección.
                        bill.Product = (VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN), bill.Product.Id);

                        bill.Product.Bills
                        .Add (bill);
                }

                session.Save (bill);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bill.Id;
}

//Sin e: ReadOID
//Con e: BillEN
public BillEN ReadOID (int id
                       )
{
        BillEN billEN = null;

        try
        {
                SessionInitializeTransaction ();
                billEN = (BillEN)session.Get (typeof(BillEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return billEN;
}

public System.Collections.Generic.IList<BillEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BillEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(BillEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<BillEN>();
                else
                        result = session.CreateCriteria (typeof(BillEN)).List<BillEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> BillsByUser (int p_user)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM BillEN self where FROM BillEN as bill where bill.User = :p_user";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("BillENbillsByUserHQL");
                query.SetParameter ("p_user", p_user);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in BillCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
