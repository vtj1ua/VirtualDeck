
using System;
// Definición clase PackEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class PackEN                                                                 : VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN


{
/**
 *	Atributo type
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type;



/**
 *	Atributo maxNumCards
 */
private int maxNumCards;



/**
 *	Atributo userPacks
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks;



/**
 *	Atributo minNumCards
 */
private int minNumCards;






public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum Type {
        get { return type; } set { type = value;  }
}



public virtual int MaxNumCards {
        get { return maxNumCards; } set { maxNumCards = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacks {
        get { return userPacks; } set { userPacks = value;  }
}



public virtual int MinNumCards {
        get { return minNumCards; } set { minNumCards = value;  }
}





public PackEN() : base ()
{
        userPacks = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN>();
}



public PackEN(int id, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type, int maxNumCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, int minNumCards
              , string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills
              )
{
        this.init (Id, type, maxNumCards, userPacks, minNumCards, name, description, price, img, comments, bills);
}


public PackEN(PackEN pack)
{
        this.init (Id, pack.Type, pack.MaxNumCards, pack.UserPacks, pack.MinNumCards, pack.Name, pack.Description, pack.Price, pack.Img, pack.Comments, pack.Bills);
}

private void init (int id
                   , VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum type, int maxNumCards, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, int minNumCards, string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills)
{
        this.Id = id;


        this.Type = type;

        this.MaxNumCards = maxNumCards;

        this.UserPacks = userPacks;

        this.MinNumCards = minNumCards;

        this.Name = name;

        this.Description = description;

        this.Price = price;

        this.Img = img;

        this.Comments = comments;

        this.Bills = bills;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PackEN t = obj as PackEN;
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
