
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface ITokenPackCAD
{
TokenPackEN ReadOIDDefault (int id
                            );

void ModifyDefault (TokenPackEN tokenPack);

System.Collections.Generic.IList<TokenPackEN> ReadAllDefault (int first, int size);



int New_ (TokenPackEN tokenPack);

void Modify (TokenPackEN tokenPack);


void Destroy (int id
              );


TokenPackEN ReadOID (int id
                     );


System.Collections.Generic.IList<TokenPackEN> ReadAll (int first, int size);
}
}
