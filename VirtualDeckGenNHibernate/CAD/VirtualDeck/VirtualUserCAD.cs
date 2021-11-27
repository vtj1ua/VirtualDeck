
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
 * Clase VirtualUser:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class VirtualUserCAD : BasicCAD, IVirtualUserCAD
{
public VirtualUserCAD() : base ()
{
}

public VirtualUserCAD(ISession sessionAux) : base (sessionAux)
{
}



public VirtualUserEN ReadOIDDefault (int id
                                     )
{
        VirtualUserEN virtualUserEN = null;

        try
        {
                SessionInitializeTransaction ();
                virtualUserEN = (VirtualUserEN)session.Get (typeof(VirtualUserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return virtualUserEN;
}

public System.Collections.Generic.IList<VirtualUserEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VirtualUserEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VirtualUserEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VirtualUserEN>();
                        else
                                result = session.CreateCriteria (typeof(VirtualUserEN)).List<VirtualUserEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VirtualUserEN virtualUser)
{
        try
        {
                SessionInitializeTransaction ();
                VirtualUserEN virtualUserEN = (VirtualUserEN)session.Load (typeof(VirtualUserEN), virtualUser.Id);

                virtualUserEN.Pass = virtualUser.Pass;


                virtualUserEN.UserName = virtualUser.UserName;


                virtualUserEN.Email = virtualUser.Email;


                virtualUserEN.Description = virtualUser.Description;


                virtualUserEN.Tokens = virtualUser.Tokens;


                virtualUserEN.Img = virtualUser.Img;


                virtualUserEN.CombatStatus = virtualUser.CombatStatus;










                session.Update (virtualUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VirtualUserEN virtualUser)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (virtualUser);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return virtualUser.Id;
}

public void Modify (VirtualUserEN virtualUser)
{
        try
        {
                SessionInitializeTransaction ();
                VirtualUserEN virtualUserEN = (VirtualUserEN)session.Load (typeof(VirtualUserEN), virtualUser.Id);

                virtualUserEN.Pass = virtualUser.Pass;


                virtualUserEN.UserName = virtualUser.UserName;


                virtualUserEN.Email = virtualUser.Email;


                virtualUserEN.Description = virtualUser.Description;


                virtualUserEN.Tokens = virtualUser.Tokens;


                virtualUserEN.Img = virtualUser.Img;


                virtualUserEN.CombatStatus = virtualUser.CombatStatus;

                session.Update (virtualUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
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
                VirtualUserEN virtualUserEN = (VirtualUserEN)session.Load (typeof(VirtualUserEN), id);
                session.Delete (virtualUserEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: VirtualUserEN
public VirtualUserEN ReadOID (int id
                              )
{
        VirtualUserEN virtualUserEN = null;

        try
        {
                SessionInitializeTransaction ();
                virtualUserEN = (VirtualUserEN)session.Get (typeof(VirtualUserEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return virtualUserEN;
}

public System.Collections.Generic.IList<VirtualUserEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VirtualUserEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VirtualUserEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VirtualUserEN>();
                else
                        result = session.CreateCriteria (typeof(VirtualUserEN)).List<VirtualUserEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> UserByName (string p_userName)
{
        System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VirtualUserEN self where FROM VirtualUserEN as u WHERE u.UserName LIKE :p_userName";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VirtualUserENuserByNameHQL");
                query.SetParameter ("p_userName", p_userName);

                result = query.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in VirtualUserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
