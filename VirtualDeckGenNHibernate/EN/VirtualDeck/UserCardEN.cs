
using System;
// Definición clase UserCardEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class UserCardEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type;



/**
 *	Atributo rarity
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum rarity;



/**
 *	Atributo speed
 */
private int speed;



/**
 *	Atributo defense
 */
private int defense;



/**
 *	Atributo attack
 */
private int attack;



/**
 *	Atributo health
 */
private int health;



/**
 *	Atributo level
 */
private int level;



/**
 *	Atributo experience
 */
private int experience;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo img
 */
private string img;



/**
 *	Atributo purchaseDate
 */
private Nullable<DateTime> purchaseDate;



/**
 *	Atributo user
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user;



/**
 *	Atributo userPack
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN userPack;



/**
 *	Atributo offeredTradeOffs
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> offeredTradeOffs;



/**
 *	Atributo attackMoves
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves;



/**
 *	Atributo card
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN card;



/**
 *	Atributo combats
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats;



/**
 *	Atributo givenTradeOffs
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> givenTradeOffs;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum Type {
        get { return type; } set { type = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum Rarity {
        get { return rarity; } set { rarity = value;  }
}



public virtual int Speed {
        get { return speed; } set { speed = value;  }
}



public virtual int Defense {
        get { return defense; } set { defense = value;  }
}



public virtual int Attack {
        get { return attack; } set { attack = value;  }
}



public virtual int Health {
        get { return health; } set { health = value;  }
}



public virtual int Level {
        get { return level; } set { level = value;  }
}



public virtual int Experience {
        get { return experience; } set { experience = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}



public virtual Nullable<DateTime> PurchaseDate {
        get { return purchaseDate; } set { purchaseDate = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN User {
        get { return user; } set { user = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN UserPack {
        get { return userPack; } set { userPack = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> OfferedTradeOffs {
        get { return offeredTradeOffs; } set { offeredTradeOffs = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> AttackMoves {
        get { return attackMoves; } set { attackMoves = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN Card {
        get { return card; } set { card = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> Combats {
        get { return combats; } set { combats = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> GivenTradeOffs {
        get { return givenTradeOffs; } set { givenTradeOffs = value;  }
}





public UserCardEN()
{
        offeredTradeOffs = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
        attackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        combats = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN>();
        givenTradeOffs = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
}



public UserCardEN(int id, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum rarity, int speed, int defense, int attack, int health, int level, int experience, string name, string img, Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN userPack, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> offeredTradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves, VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN card, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> givenTradeOffs
                  )
{
        this.init (Id, type, rarity, speed, defense, attack, health, level, experience, name, img, purchaseDate, user, userPack, offeredTradeOffs, attackMoves, card, combats, givenTradeOffs);
}


public UserCardEN(UserCardEN userCard)
{
        this.init (Id, userCard.Type, userCard.Rarity, userCard.Speed, userCard.Defense, userCard.Attack, userCard.Health, userCard.Level, userCard.Experience, userCard.Name, userCard.Img, userCard.PurchaseDate, userCard.User, userCard.UserPack, userCard.OfferedTradeOffs, userCard.AttackMoves, userCard.Card, userCard.Combats, userCard.GivenTradeOffs);
}

private void init (int id
                   , VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum rarity, int speed, int defense, int attack, int health, int level, int experience, string name, string img, Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN userPack, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> offeredTradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN> attackMoves, VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN card, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> givenTradeOffs)
{
        this.Id = id;


        this.Type = type;

        this.Rarity = rarity;

        this.Speed = speed;

        this.Defense = defense;

        this.Attack = attack;

        this.Health = health;

        this.Level = level;

        this.Experience = experience;

        this.Name = name;

        this.Img = img;

        this.PurchaseDate = purchaseDate;

        this.User = user;

        this.UserPack = userPack;

        this.OfferedTradeOffs = offeredTradeOffs;

        this.AttackMoves = attackMoves;

        this.Card = card;

        this.Combats = combats;

        this.GivenTradeOffs = givenTradeOffs;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserCardEN t = obj as UserCardEN;
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
