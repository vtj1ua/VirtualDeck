
using System;
// Definición clase CardEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class CardEN                                                                 : VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN


{
/**
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type;



/**
 *	Atributo health
 */
private int health;



/**
 *	Atributo attack
 */
private int attack;



/**
 *	Atributo defense
 */
private int defense;



/**
 *	Atributo speed
 */
private int speed;



/**
 *	Atributo rarity
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity;



/**
 *	Atributo tradeOffs
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> tradeOffs;



/**
 *	Atributo attackMoves
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves;



/**
 *	Atributo userCards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards;






public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum Type {
        get { return type; } set { type = value;  }
}



public virtual int Health {
        get { return health; } set { health = value;  }
}



public virtual int Attack {
        get { return attack; } set { attack = value;  }
}



public virtual int Defense {
        get { return defense; } set { defense = value;  }
}



public virtual int Speed {
        get { return speed; } set { speed = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum Rarity {
        get { return rarity; } set { rarity = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradeOffs {
        get { return tradeOffs; } set { tradeOffs = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> AttackMoves {
        get { return attackMoves; } set { attackMoves = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCards {
        get { return userCards; } set { userCards = value;  }
}





public CardEN() : base ()
{
        tradeOffs = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
        attackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
}



public CardEN(int id, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, int health, int attack, int defense, int speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> tradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards
              , string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, Nullable<DateTime> registryDate
              )
{
        this.init (Id, type, health, attack, defense, speed, rarity, tradeOffs, attackMoves, userCards, name, description, price, img, comments, bills, registryDate);
}


public CardEN(CardEN card)
{
        this.init (Id, card.Type, card.Health, card.Attack, card.Defense, card.Speed, card.Rarity, card.TradeOffs, card.AttackMoves, card.UserCards, card.Name, card.Description, card.Price, card.Img, card.Comments, card.Bills, card.RegistryDate);
}

private void init (int id
                   , VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, int health, int attack, int defense, int speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> tradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, Nullable<DateTime> registryDate)
{
        this.Id = id;


        this.Type = type;

        this.Health = health;

        this.Attack = attack;

        this.Defense = defense;

        this.Speed = speed;

        this.Rarity = rarity;

        this.TradeOffs = tradeOffs;

        this.AttackMoves = attackMoves;

        this.UserCards = userCards;

        this.Name = name;

        this.Description = description;

        this.Price = price;

        this.Img = img;

        this.Comments = comments;

        this.Bills = bills;

        this.RegistryDate = registryDate;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CardEN t = obj as CardEN;
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
