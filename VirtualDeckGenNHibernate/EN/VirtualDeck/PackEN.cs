
using System;
// Definición clase PackEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class PackEN                                                                 : VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN


{
/**
 *	Atributo userPacks
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks;



/**
 *	Atributo rarity
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity;



/**
 *	Atributo maxNumCards
 */
private int maxNumCards;



/**
 *	Atributo minNumCards
 */
private int minNumCards;



/**
 *	Atributo cardTypes
 */
private VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum cardTypes;



/**
 *	Atributo cardsRarityProbabilities
 */
private System.Collections.Generic.IList<float> cardsRarityProbabilities;






public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacks {
        get { return userPacks; } set { userPacks = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum Rarity {
        get { return rarity; } set { rarity = value;  }
}



public virtual int MaxNumCards {
        get { return maxNumCards; } set { maxNumCards = value;  }
}



public virtual int MinNumCards {
        get { return minNumCards; } set { minNumCards = value;  }
}



public virtual VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum CardTypes {
        get { return cardTypes; } set { cardTypes = value;  }
}



public virtual System.Collections.Generic.IList<float> CardsRarityProbabilities {
        get { return cardsRarityProbabilities; } set { cardsRarityProbabilities = value;  }
}





public PackEN() : base ()
{
        userPacks = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN>();
}



public PackEN(int id, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, int maxNumCards, int minNumCards, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum cardTypes, System.Collections.Generic.IList<float> cardsRarityProbabilities
              , string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, Nullable<DateTime> registryDate
              )
{
        this.init (Id, userPacks, rarity, maxNumCards, minNumCards, cardTypes, cardsRarityProbabilities, name, description, price, img, comments, bills, registryDate);
}


public PackEN(PackEN pack)
{
        this.init (Id, pack.UserPacks, pack.Rarity, pack.MaxNumCards, pack.MinNumCards, pack.CardTypes, pack.CardsRarityProbabilities, pack.Name, pack.Description, pack.Price, pack.Img, pack.Comments, pack.Bills, pack.RegistryDate);
}

private void init (int id
                   , System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> userPacks, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum rarity, int maxNumCards, int minNumCards, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum cardTypes, System.Collections.Generic.IList<float> cardsRarityProbabilities, string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, Nullable<DateTime> registryDate)
{
        this.Id = id;


        this.UserPacks = userPacks;

        this.Rarity = rarity;

        this.MaxNumCards = maxNumCards;

        this.MinNumCards = minNumCards;

        this.CardTypes = cardTypes;

        this.CardsRarityProbabilities = cardsRarityProbabilities;

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
