
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IProductCAD
{
ProductEN ReadOIDDefault (int id
                          );

void ModifyDefault (ProductEN product);

System.Collections.Generic.IList<ProductEN> ReadAllDefault (int first, int size);



int New_ (ProductEN product);

void Modify (ProductEN product);


void Destroy (int id
              );


ProductEN ReadOID (int id
                   );


System.Collections.Generic.IList<ProductEN> ReadAll (int first, int size);
}
}
