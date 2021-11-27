
using System;
// Definición clase TradeOffEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class TradeOffEN
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
 *	Atributo owner
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN owner;



/**
 *	Atributo desiredCard
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN desiredCard;



/**
 *	Atributo offeredUserCard
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN offeredUserCard;



/**
 *	Atributo state
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TradeStateEnum state;



/**
 *	Atributo notification
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification;



/**
 *	Atributo exchanger
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN exchanger;



/**
 *	Atributo givenUserCard
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN givenUserCard;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN Owner {
        get { return owner; } set { owner = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN DesiredCard {
        get { return desiredCard; } set { desiredCard = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN OfferedUserCard {
        get { return offeredUserCard; } set { offeredUserCard = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TradeStateEnum State {
        get { return state; } set { state = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN Notification {
        get { return notification; } set { notification = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN Exchanger {
        get { return exchanger; } set { exchanger = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN GivenUserCard {
        get { return givenUserCard; } set { givenUserCard = value;  }
}





public TradeOffEN()
{
}



public TradeOffEN(int id, Nullable<DateTime> date, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN owner, VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN desiredCard, VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN offeredUserCard, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TradeStateEnum state, VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN exchanger, VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN givenUserCard
                  )
{
        this.init (Id, date, owner, desiredCard, offeredUserCard, state, notification, exchanger, givenUserCard);
}


public TradeOffEN(TradeOffEN tradeOff)
{
        this.init (Id, tradeOff.Date, tradeOff.Owner, tradeOff.DesiredCard, tradeOff.OfferedUserCard, tradeOff.State, tradeOff.Notification, tradeOff.Exchanger, tradeOff.GivenUserCard);
}

private void init (int id
                   , Nullable<DateTime> date, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN owner, VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN desiredCard, VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN offeredUserCard, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.TradeStateEnum state, VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN notification, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN exchanger, VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN givenUserCard)
{
        this.Id = id;


        this.Date = date;

        this.Owner = owner;

        this.DesiredCard = desiredCard;

        this.OfferedUserCard = offeredUserCard;

        this.State = state;

        this.Notification = notification;

        this.Exchanger = exchanger;

        this.GivenUserCard = givenUserCard;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TradeOffEN t = obj as TradeOffEN;
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
