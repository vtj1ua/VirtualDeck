
using System;
// Definición clase VirtualUserEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class VirtualUserEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo userName
 */
private string userName;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo description
 */
private string description;



/**
 *	Atributo tokens
 */
private int tokens;



/**
 *	Atributo img
 */
private string img;



/**
 *	Atributo combatStatus
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CombatStatusEnum combatStatus;



/**
 *	Atributo userCards
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards;



/**
 *	Atributo publishedTradeOffs
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> publishedTradeOffs;



/**
 *	Atributo comments
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments;



/**
 *	Atributo userPacks
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks;



/**
 *	Atributo bills
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills;



/**
 *	Atributo notifications
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN> notifications;



/**
 *	Atributo combats
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats;



/**
 *	Atributo combatsWon
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combatsWon;



/**
 *	Atributo exchangedTradeOffs
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> exchangedTradeOffs;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string UserName {
        get { return userName; } set { userName = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}



public virtual int Tokens {
        get { return tokens; } set { tokens = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CombatStatusEnum CombatStatus {
        get { return combatStatus; } set { combatStatus = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCards {
        get { return userCards; } set { userCards = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> PublishedTradeOffs {
        get { return publishedTradeOffs; } set { publishedTradeOffs = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> Comments {
        get { return comments; } set { comments = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacks {
        get { return userPacks; } set { userPacks = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> Bills {
        get { return bills; } set { bills = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN> Notifications {
        get { return notifications; } set { notifications = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> Combats {
        get { return combats; } set { combats = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> CombatsWon {
        get { return combatsWon; } set { combatsWon = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> ExchangedTradeOffs {
        get { return exchangedTradeOffs; } set { exchangedTradeOffs = value;  }
}





public VirtualUserEN()
{
        userCards = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN>();
        publishedTradeOffs = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
        comments = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN>();
        userPacks = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN>();
        bills = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN>();
        notifications = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN>();
        combats = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN>();
        combatsWon = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN>();
        exchangedTradeOffs = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN>();
}



public VirtualUserEN(int id, String pass, string userName, string email, string description, int tokens, string img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CombatStatusEnum combatStatus, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> publishedTradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN> notifications, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combatsWon, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> exchangedTradeOffs
                     )
{
        this.init (Id, pass, userName, email, description, tokens, img, combatStatus, userCards, publishedTradeOffs, comments, userPacks, bills, notifications, combats, combatsWon, exchangedTradeOffs);
}


public VirtualUserEN(VirtualUserEN virtualUser)
{
        this.init (Id, virtualUser.Pass, virtualUser.UserName, virtualUser.Email, virtualUser.Description, virtualUser.Tokens, virtualUser.Img, virtualUser.CombatStatus, virtualUser.UserCards, virtualUser.PublishedTradeOffs, virtualUser.Comments, virtualUser.UserPacks, virtualUser.Bills, virtualUser.Notifications, virtualUser.Combats, virtualUser.CombatsWon, virtualUser.ExchangedTradeOffs);
}

private void init (int id
                   , String pass, string userName, string email, string description, int tokens, string img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CombatStatusEnum combatStatus, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> userCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> publishedTradeOffs, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN> notifications, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combats, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CombatEN> combatsWon, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> exchangedTradeOffs)
{
        this.Id = id;


        this.Pass = pass;

        this.UserName = userName;

        this.Email = email;

        this.Description = description;

        this.Tokens = tokens;

        this.Img = img;

        this.CombatStatus = combatStatus;

        this.UserCards = userCards;

        this.PublishedTradeOffs = publishedTradeOffs;

        this.Comments = comments;

        this.UserPacks = userPacks;

        this.Bills = bills;

        this.Notifications = notifications;

        this.Combats = combats;

        this.CombatsWon = combatsWon;

        this.ExchangedTradeOffs = exchangedTradeOffs;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VirtualUserEN t = obj as VirtualUserEN;
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
