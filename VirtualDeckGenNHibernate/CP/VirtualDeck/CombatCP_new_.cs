
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Combat_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CombatCP : BasicCP
{
public VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN New_ (Nullable<DateTime> p_date, System.Collections.Generic.IList<int> p_attackMovesUserCard1, System.Collections.Generic.IList<int> p_userCards, System.Collections.Generic.IList<int> p_attackMovesUserCard2, System.Collections.Generic.IList<int> p_users)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Combat_new_) ENABLED START*/

        ICombatCAD combatCAD = null;
        CombatCEN combatCEN = null;

        VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN result = null;


        try
        {
                SessionInitializeTransaction ();
                combatCAD = new CombatCAD (session);
                combatCEN = new  CombatCEN (combatCAD);




                int oid;
                //Initialized CombatEN
                CombatEN combatEN;
                combatEN = new CombatEN ();
                combatEN.Date = p_date;


                combatEN.AttackMovesUserCard1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
                if (p_attackMovesUserCard1 != null) {
                        for (int item : p_attackMovesUserCard1) {
                                VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                                en.Id = item;
                                combatEN.AttackMovesUserCard1 ().Add (en);
                        }
                }

                else{
                        combatEN.AttackMovesUserCard1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
                }


                combatEN.UserCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                if (p_userCards != null) {
                        for (int item : p_userCards) {
                                VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN ();
                                en.Id = item;
                                combatEN.UserCards ().Add (en);
                        }
                }

                else{
                        combatEN.UserCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
                }


                combatEN.AttackMovesUserCard2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
                if (p_attackMovesUserCard2 != null) {
                        for (int item : p_attackMovesUserCard2) {
                                VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                                en.Id = item;
                                combatEN.AttackMovesUserCard2 ().Add (en);
                        }
                }

                else{
                        combatEN.AttackMovesUserCard2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
                }


                combatEN.Users = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
                if (p_users != null) {
                        for (int item : p_users) {
                                VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                                en.Id = item;
                                combatEN.Users ().Add (en);
                        }
                }

                else{
                        combatEN.Users = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
                }

                //Call to CombatCAD

                oid = combatCAD.New_ (combatEN);
                result = combatCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
