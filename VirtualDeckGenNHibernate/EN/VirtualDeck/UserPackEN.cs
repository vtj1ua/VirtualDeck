
using System;
// Definición clase UserPackEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class UserPackEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo purchaseDate
 */
private Nullable<DateTime> purchaseDate;



/**
 *	Atributo rarity
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity;



/**
 *	Atributo user
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user;



/**
 *	Atributo userCards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards;



/**
 *	Atributo pack
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN pack;



/**
 *	Atributo name
 */
private string name;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> PurchaseDate {
        get { return purchaseDate; } set { purchaseDate = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum Rarity {
        get { return rarity; } set { rarity = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN User {
        get { return user; } set { user = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCards {
        get { return userCards; } set { userCards = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN Pack {
        get { return pack; } set { pack = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}





public UserPackEN()
{
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
}



public UserPackEN(int id, Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN pack, string name
                  )
{
        this.init (Id, purchaseDate, rarity, user, userCards, pack, name);
}


public UserPackEN(UserPackEN userPack)
{
        this.init (Id, userPack.PurchaseDate, userPack.Rarity, userPack.User, userPack.UserCards, userPack.Pack, userPack.Name);
}

private void init (int id
                   , Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN pack, string name)
{
        this.Id = id;


        this.PurchaseDate = purchaseDate;

        this.Rarity = rarity;

        this.User = user;

        this.UserCards = userCards;

        this.Pack = pack;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserPackEN t = obj as UserPackEN;
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
