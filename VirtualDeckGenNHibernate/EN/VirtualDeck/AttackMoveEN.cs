
using System;
// Definición clase AttackMoveEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class AttackMoveEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type;



/**
 *	Atributo userCards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards;



/**
 *	Atributo cards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> cards;



/**
 *	Atributo combats1
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats1;



/**
 *	Atributo combats2
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats2;



/**
 *	Atributo description
 */
private string description;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum Type {
        get { return type; } set { type = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCards {
        get { return userCards; } set { userCards = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> Cards {
        get { return cards; } set { cards = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> Combats1 {
        get { return combats1; } set { combats1 = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> Combats2 {
        get { return combats2; } set { combats2 = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}





public AttackMoveEN()
{
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
        cards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN>();
        combats1 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN>();
        combats2 = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN>();
}



public AttackMoveEN(int id, string name, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> cards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats1, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats2, string description
                    )
{
        this.init (Id, name, type, userCards, cards, combats1, combats2, description);
}


public AttackMoveEN(AttackMoveEN attackMove)
{
        this.init (Id, attackMove.Name, attackMove.Type, attackMove.UserCards, attackMove.Cards, attackMove.Combats1, attackMove.Combats2, attackMove.Description);
}

private void init (int id
                   , string name, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> cards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats1, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats2, string description)
{
        this.Id = id;


        this.Name = name;

        this.Type = type;

        this.UserCards = userCards;

        this.Cards = cards;

        this.Combats1 = combats1;

        this.Combats2 = combats2;

        this.Description = description;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AttackMoveEN t = obj as AttackMoveEN;
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
