
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
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type;



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






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> PurchaseDate {
        get { return purchaseDate; } set { purchaseDate = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum Type {
        get { return type; } set { type = value;  }
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





public UserPackEN()
{
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
}



public UserPackEN(int id, Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN pack
                  )
{
        this.init (Id, purchaseDate, type, user, userCards, pack);
}


public UserPackEN(UserPackEN userPack)
{
        this.init (Id, userPack.PurchaseDate, userPack.Type, userPack.User, userPack.UserCards, userPack.Pack);
}

private void init (int id
                   , Nullable<DateTime> purchaseDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN pack)
{
        this.Id = id;


        this.PurchaseDate = purchaseDate;

        this.Type = type;

        this.User = user;

        this.UserCards = userCards;

        this.Pack = pack;
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
