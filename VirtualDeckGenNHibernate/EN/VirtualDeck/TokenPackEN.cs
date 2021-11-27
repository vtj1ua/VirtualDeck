
using System;
// Definición clase TokenPackEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class TokenPackEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo img
 */
private string img;



/**
 *	Atributo price
 */
private double price;



/**
 *	Atributo description
 */
private string description;



/**
 *	Atributo bills
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills;



/**
 *	Atributo tokens
 */
private int tokens;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}



public virtual double Price {
        get { return price; } set { price = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> Bills {
        get { return bills; } set { bills = value;  }
}



public virtual int Tokens {
        get { return tokens; } set { tokens = value;  }
}





public TokenPackEN()
{
        bills = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN>();
}



public TokenPackEN(int id, string name, string img, double price, string description, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, int tokens
                   )
{
        this.init (Id, name, img, price, description, bills, tokens);
}


public TokenPackEN(TokenPackEN tokenPack)
{
        this.init (Id, tokenPack.Name, tokenPack.Img, tokenPack.Price, tokenPack.Description, tokenPack.Bills, tokenPack.Tokens);
}

private void init (int id
                   , string name, string img, double price, string description, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills, int tokens)
{
        this.Id = id;


        this.Name = name;

        this.Img = img;

        this.Price = price;

        this.Description = description;

        this.Bills = bills;

        this.Tokens = tokens;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TokenPackEN t = obj as TokenPackEN;
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
