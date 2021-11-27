

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class CombatCEN
 *
 */
public partial class CombatCEN
{
private ICombatCAD _ICombatCAD;

public CombatCEN()
{
        this._ICombatCAD = new CombatCAD ();
}

public CombatCEN(ICombatCAD _ICombatCAD)
{
        this._ICombatCAD = _ICombatCAD;
}

public ICombatCAD get_ICombatCAD ()
{
        return this._ICombatCAD;
}

public int New_ (Nullable<DateTime> p_date, System.Collections.Generic.IList<int> p_attackMovesUserCard1, System.Collections.Generic.IList<int> p_userCards, System.Collections.Generic.IList<int> p_attackMovesUserCard2, System.Collections.Generic.IList<int> p_users)
{
        CombatEN combatEN = null;
        int oid;

        //Initialized CombatEN
        combatEN = new CombatEN ();
        combatEN.Date = p_date;


        combatEN.AttackMovesUserCard1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        if (p_attackMovesUserCard1 != null) {
                foreach (int item in p_attackMovesUserCard1) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                        en.Id = item;
                        combatEN.AttackMovesUserCard1.Add (en);
                }
        }

        else{
                combatEN.AttackMovesUserCard1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        }


        combatEN.UserCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
        if (p_userCards != null) {
                foreach (int item in p_userCards) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN ();
                        en.Id = item;
                        combatEN.UserCards.Add (en);
                }
        }

        else{
                combatEN.UserCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
        }


        combatEN.AttackMovesUserCard2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        if (p_attackMovesUserCard2 != null) {
                foreach (int item in p_attackMovesUserCard2) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                        en.Id = item;
                        combatEN.AttackMovesUserCard2.Add (en);
                }
        }

        else{
                combatEN.AttackMovesUserCard2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        }


        combatEN.Users = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
        if (p_users != null) {
                foreach (int item in p_users) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                        en.Id = item;
                        combatEN.Users.Add (en);
                }
        }

        else{
                combatEN.Users = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
        }

        //Call to CombatCAD

        oid = _ICombatCAD.New_ (combatEN);
        return oid;
}

public void Modify (int p_Combat_OID, Nullable<DateTime> p_date)
{
        CombatEN combatEN = null;

        //Initialized CombatEN
        combatEN = new CombatEN ();
        combatEN.Id = p_Combat_OID;
        combatEN.Date = p_date;
        //Call to CombatCAD

        _ICombatCAD.Modify (combatEN);
}

public void Destroy (int id
                     )
{
        _ICombatCAD.Destroy (id);
}

public CombatEN ReadOID (int id
                         )
{
        CombatEN combatEN = null;

        combatEN = _ICombatCAD.ReadOID (id);
        return combatEN;
}

public System.Collections.Generic.IList<CombatEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CombatEN> list = null;

        list = _ICombatCAD.ReadAll (first, size);
        return list;
}
}
}
