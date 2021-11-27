
using System;
// Definición clase BillEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class BillEN
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
 *	Atributo product
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product;



/**
 *	Atributo tokenPack
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN tokenPack;



/**
 *	Atributo amount
 */
private int amount;



/**
 *	Atributo user
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user;



/**
 *	Atributo notification
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN Product {
        get { return product; } set { product = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN TokenPack {
        get { return tokenPack; } set { tokenPack = value;  }
}



public virtual int Amount {
        get { return amount; } set { amount = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN User {
        get { return user; } set { user = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN Notification {
        get { return notification; } set { notification = value;  }
}





public BillEN()
{
}



public BillEN(int id, Nullable<DateTime> date, VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product, VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN tokenPack, int amount, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification
              )
{
        this.init (Id, date, product, tokenPack, amount, user, notification);
}


public BillEN(BillEN bill)
{
        this.init (Id, bill.Date, bill.Product, bill.TokenPack, bill.Amount, bill.User, bill.Notification);
}

private void init (int id
                   , Nullable<DateTime> date, VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product, VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN tokenPack, int amount, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification)
{
        this.Id = id;


        this.Date = date;

        this.Product = product;

        this.TokenPack = tokenPack;

        this.Amount = amount;

        this.User = user;

        this.Notification = notification;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BillEN t = obj as BillEN;
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
