
using System;
// Definición clase CommentEN
namespace VirtualDeckGenNHibernate.EN.VirtualDeck
{
public partial class CommentEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo text
 */
private string text;



/**
 *	Atributo publishDate
 */
private Nullable<DateTime> publishDate;



/**
 *	Atributo product
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product;



/**
 *	Atributo user
 */
private VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Text {
        get { return text; } set { text = value;  }
}



public virtual Nullable<DateTime> PublishDate {
        get { return publishDate; } set { publishDate = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN Product {
        get { return product; } set { product = value;  }
}



public virtual VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN User {
        get { return user; } set { user = value;  }
}





public CommentEN()
{
}



public CommentEN(int id, string text, Nullable<DateTime> publishDate, VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user
                 )
{
        this.init (Id, text, publishDate, product, user);
}


public CommentEN(CommentEN comment)
{
        this.init (Id, comment.Text, comment.PublishDate, comment.Product, comment.User);
}

private void init (int id
                   , string text, Nullable<DateTime> publishDate, VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN product, VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN user)
{
        this.Id = id;


        this.Text = text;

        this.PublishDate = publishDate;

        this.Product = product;

        this.User = user;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CommentEN t = obj as CommentEN;
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
