
using System;
// Definición clase ProductEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class ProductEN
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
 *	Atributo description
 */
private string description;



/**
 *	Atributo price
 */
private int price;



/**
 *	Atributo img
 */
private string img;



/**
 *	Atributo comments
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments;



/**
 *	Atributo bills
 */
private System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}



public virtual int Price {
        get { return price; } set { price = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> Comments {
        get { return comments; } set { comments = value;  }
}



public virtual System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> Bills {
        get { return bills; } set { bills = value;  }
}





public ProductEN()
{
        comments = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN>();
        bills = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN>();
}



public ProductEN(int id, string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills
                 )
{
        this.init (Id, name, description, price, img, comments, bills);
}


public ProductEN(ProductEN product)
{
        this.init (Id, product.Name, product.Description, product.Price, product.Img, product.Comments, product.Bills);
}

private void init (int id
                   , string name, string description, int price, string img, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CommentEN> comments, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> bills)
{
        this.Id = id;


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
        ProductEN t = obj as ProductEN;
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
