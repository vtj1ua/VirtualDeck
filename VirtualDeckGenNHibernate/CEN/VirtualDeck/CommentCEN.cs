

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class CommentCEN
 *
 */
public partial class CommentCEN
{
private ICommentCAD _ICommentCAD;

public CommentCEN()
{
        this._ICommentCAD = new CommentCAD ();
}

public CommentCEN(ICommentCAD _ICommentCAD)
{
        this._ICommentCAD = _ICommentCAD;
}

public ICommentCAD get_ICommentCAD ()
{
        return this._ICommentCAD;
}

public void Modify (int p_Comment_OID, string p_text, Nullable<DateTime> p_publishDate)
{
        CommentEN commentEN = null;

        //Initialized CommentEN
        commentEN = new CommentEN ();
        commentEN.Id = p_Comment_OID;
        commentEN.Text = p_text;
        commentEN.PublishDate = p_publishDate;
        //Call to CommentCAD

        _ICommentCAD.Modify (commentEN);
}

public void Destroy (int id
                     )
{
        _ICommentCAD.Destroy (id);
}

public CommentEN ReadOID (int id
                          )
{
        CommentEN commentEN = null;

        commentEN = _ICommentCAD.ReadOID (id);
        return commentEN;
}

public System.Collections.Generic.IList<CommentEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CommentEN> list = null;

        list = _ICommentCAD.ReadAll (first, size);
        return list;
}
}
}
