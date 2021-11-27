
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Comment_publish) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class CommentCEN
{
public int Publish (string p_text, int p_product, int p_user)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Comment_publish_customized) ENABLED START*/

        CommentEN commentEN = null;

        int oid;

        //Initialized CommentEN
        commentEN = new CommentEN ();
        commentEN.Text = p_text;


        if (p_product != -1) {
                commentEN.Product = new VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN ();
                commentEN.Product.Id = p_product;
        }


        if (p_user != -1) {
                commentEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                commentEN.User.Id = p_user;
        }

        commentEN.PublishDate = DateTime.Now;

        //Call to CommentCAD

        oid = _ICommentCAD.Publish (commentEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
