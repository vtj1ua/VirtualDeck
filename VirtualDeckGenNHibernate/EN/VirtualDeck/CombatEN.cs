
using System;
// Definición clase CombatEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class CombatEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;



/**
 *	Atributo attackMovesUserCard1
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard1;



/**
 *	Atributo userCards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards;



/**
 *	Atributo attackMovesUserCard2
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard2;



/**
 *	Atributo users
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> users;



/**
 *	Atributo winner
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN winner;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> AttackMovesUserCard1 {
        get { return attackMovesUserCard1; } set { attackMovesUserCard1 = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCards {
        get { return userCards; } set { userCards = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> AttackMovesUserCard2 {
        get { return attackMovesUserCard2; } set { attackMovesUserCard2 = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> Users {
        get { return users; } set { users = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN Winner {
        get { return winner; } set { winner = value;  }
}





public CombatEN()
{
        attackMovesUserCard1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
        attackMovesUserCard2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        users = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN>();
}



public CombatEN(int id, Nullable<DateTime> date, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard1, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard2, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> users, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN winner
                )
{
        this.init (Id, date, attackMovesUserCard1, userCards, attackMovesUserCard2, users, winner);
}


public CombatEN(CombatEN combat)
{
        this.init (Id, combat.Date, combat.AttackMovesUserCard1, combat.UserCards, combat.AttackMovesUserCard2, combat.Users, combat.Winner);
}

private void init (int id
                   , Nullable<DateTime> date, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard1, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMovesUserCard2, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> users, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN winner)
{
        this.Id = id;


        this.Date = date;

        this.AttackMovesUserCard1 = attackMovesUserCard1;

        this.UserCards = userCards;

        this.AttackMovesUserCard2 = attackMovesUserCard2;

        this.Users = users;

        this.Winner = winner;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CombatEN t = obj as CombatEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
