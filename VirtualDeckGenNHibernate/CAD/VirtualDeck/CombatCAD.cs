
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
 * Clase Combat:
 *
 */

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial class CombatCAD : BasicCAD, ICombatCAD
{
public CombatCAD() : base ()
{
}

public CombatCAD(ISession sessionAux) : base (sessionAux)
{
}



public CombatEN ReadOIDDefault (int id
                                )
{
        CombatEN combatEN = null;

        try
        {
                SessionInitializeTransaction ();
                combatEN = (CombatEN)session.Get (typeof(CombatEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return combatEN;
}

public System.Collections.Generic.IList<CombatEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CombatEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CombatEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CombatEN>();
                        else
                                result = session.CreateCriteria (typeof(CombatEN)).List<CombatEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CombatEN combat)
{
        try
        {
                SessionInitializeTransaction ();
                CombatEN combatEN = (CombatEN)session.Load (typeof(CombatEN), combat.Id);

                combatEN.Date = combat.Date;






                session.Update (combatEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CombatEN combat)
{
        try
        {
                SessionInitializeTransaction ();
                if (combat.AttackMovesUserCard1 != null) {
                        for (int i = 0; i < combat.AttackMovesUserCard1.Count; i++) {
                                combat.AttackMovesUserCard1 [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN), combat.AttackMovesUserCard1 [i].Id);
                                combat.AttackMovesUserCard1 [i].Combats1.Add (combat);
                        }
                }
                if (combat.UserCards != null) {
                        for (int i = 0; i < combat.UserCards.Count; i++) {
                                combat.UserCards [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN), combat.UserCards [i].Id);
                                combat.UserCards [i].Combats.Add (combat);
                        }
                }
                if (combat.AttackMovesUserCard2 != null) {
                        for (int i = 0; i < combat.AttackMovesUserCard2.Count; i++) {
                                combat.AttackMovesUserCard2 [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN), combat.AttackMovesUserCard2 [i].Id);
                                combat.AttackMovesUserCard2 [i].Combats2.Add (combat);
                        }
                }
                if (combat.Users != null) {
                        for (int i = 0; i < combat.Users.Count; i++) {
                                combat.Users [i] = (VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN)session.Load (typeof(VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN), combat.Users [i].Id);
                                combat.Users [i].Combats.Add (combat);
                        }
                }

                session.Save (combat);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return combat.Id;
}

public void Modify (CombatEN combat)
{
        try
        {
                SessionInitializeTransaction ();
                CombatEN combatEN = (CombatEN)session.Load (typeof(CombatEN), combat.Id);

                combatEN.Date = combat.Date;

                session.Update (combatEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
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
                CombatEN combatEN = (CombatEN)session.Load (typeof(CombatEN), id);
                session.Delete (combatEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CombatEN
public CombatEN ReadOID (int id
                         )
{
        CombatEN combatEN = null;

        try
        {
                SessionInitializeTransaction ();
                combatEN = (CombatEN)session.Get (typeof(CombatEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return combatEN;
}

public System.Collections.Generic.IList<CombatEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CombatEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CombatEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CombatEN>();
                else
                        result = session.CreateCriteria (typeof(CombatEN)).List<CombatEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is VirtualDeckGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new VirtualDeckGenNHibernate.Exceptions.DataLayerException ("Error in CombatCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
