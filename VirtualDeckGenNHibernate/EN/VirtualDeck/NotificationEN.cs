
using System;
// Definición clase NotificationEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class NotificationEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo bill
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN bill;



/**
 *	Atributo user
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user;



/**
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum type;



/**
 *	Atributo tradeOff
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN tradeOff;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN Bill {
        get { return bill; } set { bill = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN User {
        get { return user; } set { user = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum Type {
        get { return type; } set { type = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN TradeOff {
        get { return tradeOff; } set { tradeOff = value;  }
}





public NotificationEN()
{
}



public NotificationEN(int id, VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN bill, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum type, VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN tradeOff
                      )
{
        this.init (Id, bill, user, type, tradeOff);
}


public NotificationEN(NotificationEN notification)
{
        this.init (Id, notification.Bill, notification.User, notification.Type, notification.TradeOff);
}

private void init (int id
                   , VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN bill, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TypeNotificationEnum type, VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN tradeOff)
{
        this.Id = id;


        this.Bill = bill;

        this.User = user;

        this.Type = type;

        this.TradeOff = tradeOff;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificationEN t = obj as NotificationEN;
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
