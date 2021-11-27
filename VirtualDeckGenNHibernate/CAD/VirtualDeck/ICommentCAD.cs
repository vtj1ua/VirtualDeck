
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface ICommentCAD
{
CommentEN ReadOIDDefault (int id
                          );

void ModifyDefault (CommentEN comment);

System.Collections.Generic.IList<CommentEN> ReadAllDefault (int first, int size);



int Publish (CommentEN comment);

void Modify (CommentEN comment);


void Destroy (int id
              );


CommentEN ReadOID (int id
                   );


System.Collections.Generic.IList<CommentEN> ReadAll (int first, int size);
}
}
