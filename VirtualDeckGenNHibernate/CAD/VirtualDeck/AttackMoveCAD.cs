
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
 * Clase AttackMove:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class AttackMoveCAD : BasicCAD, IAttackMoveCAD
{
public AttackMoveCAD() : base ()
{
}

public AttackMoveCAD(ISession sessionAux) : base (sessionAux)
{
}



public AttackMoveEN ReadOIDDefault (int id
                                    )
{
        AttackMoveEN attackMoveEN = null;

        try
        {
                SessionInitializeTransaction ();
                attackMoveEN = (AttackMoveEN)session.Get (typeof(AttackMoveEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return attackMoveEN;
}

public System.Collections.Generic.IList<AttackMoveEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AttackMoveEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AttackMoveEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AttackMoveEN>();
                        else
                                result = session.CreateCriteria (typeof(AttackMoveEN)).List<AttackMoveEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AttackMoveEN attackMove)
{
        try
        {
                SessionInitializeTransaction ();
                AttackMoveEN attackMoveEN = (AttackMoveEN)session.Load (typeof(AttackMoveEN), attackMove.Id);

                attackMoveEN.Name = attackMove.Name;


                attackMoveEN.Type = attackMove.Type;





                session.Update (attackMoveEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AttackMoveEN attackMove)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (attackMove);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return attackMove.Id;
}

public void Modify (AttackMoveEN attackMove)
{
        try
        {
                SessionInitializeTransaction ();
                AttackMoveEN attackMoveEN = (AttackMoveEN)session.Load (typeof(AttackMoveEN), attackMove.Id);

                attackMoveEN.Name = attackMove.Name;


                attackMoveEN.Type = attackMove.Type;

                session.Update (attackMoveEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
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
                AttackMoveEN attackMoveEN = (AttackMoveEN)session.Load (typeof(AttackMoveEN), id);
                session.Delete (attackMoveEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AttackMoveEN
public AttackMoveEN ReadOID (int id
                             )
{
        AttackMoveEN attackMoveEN = null;

        try
        {
                SessionInitializeTransaction ();
                attackMoveEN = (AttackMoveEN)session.Get (typeof(AttackMoveEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return attackMoveEN;
}

public System.Collections.Generic.IList<AttackMoveEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AttackMoveEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AttackMoveEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AttackMoveEN>();
                else
                        result = session.CreateCriteria (typeof(AttackMoveEN)).List<AttackMoveEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in AttackMoveCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
