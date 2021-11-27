
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IVirtualUserCAD
{
VirtualUserEN ReadOIDDefault (int id
                              );

void ModifyDefault (VirtualUserEN virtualUser);

System.Collections.Generic.IList<VirtualUserEN> ReadAllDefault (int first, int size);



int New_ (VirtualUserEN virtualUser);

void Modify (VirtualUserEN virtualUser);


void Destroy (int id
              );




VirtualUserEN ReadOID (int id
                       );


System.Collections.Generic.IList<VirtualUserEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> UserByName (string p_userName);
}
}
