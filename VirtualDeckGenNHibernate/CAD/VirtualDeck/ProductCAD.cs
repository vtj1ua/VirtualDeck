
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
 * Clase Product:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class ProductCAD : BasicCAD, IProductCAD
{
public ProductCAD() : base ()
{
}

public ProductCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProductEN ReadOIDDefault (int id
                                 )
{
        ProductEN productEN = null;

        try
        {
                SessionInitializeTransaction ();
                productEN = (ProductEN)session.Get (typeof(ProductEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productEN;
}

public System.Collections.Generic.IList<ProductEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductEN)).List<ProductEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductEN product)
{
        try
        {
                SessionInitializeTransaction ();
                ProductEN productEN = (ProductEN)session.Load (typeof(ProductEN), product.Id);

                productEN.Name = product.Name;


                productEN.Description = product.Description;


                productEN.Price = product.Price;


                productEN.Img = product.Img;



                session.Update (productEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProductEN product)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (product);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return product.Id;
}

public void Modify (ProductEN product)
{
        try
        {
                SessionInitializeTransaction ();
                ProductEN productEN = (ProductEN)session.Load (typeof(ProductEN), product.Id);

                productEN.Name = product.Name;


                productEN.Description = product.Description;


                productEN.Price = product.Price;


                productEN.Img = product.Img;

                session.Update (productEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
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
                ProductEN productEN = (ProductEN)session.Load (typeof(ProductEN), id);
                session.Delete (productEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProductEN
public ProductEN ReadOID (int id
                          )
{
        ProductEN productEN = null;

        try
        {
                SessionInitializeTransaction ();
                productEN = (ProductEN)session.Get (typeof(ProductEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productEN;
}

public System.Collections.Generic.IList<ProductEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductEN>();
                else
                        result = session.CreateCriteria (typeof(ProductEN)).List<ProductEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in ProductCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
