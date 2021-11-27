
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IPackCAD
{
PackEN ReadOIDDefault (int id
                       );

void ModifyDefault (PackEN pack);

System.Collections.Generic.IList<PackEN> ReadAllDefault (int first, int size);



int New_ (PackEN pack);

void Modify (PackEN pack);


void Destroy (int id
              );


PackEN ReadOID (int id
                );


System.Collections.Generic.IList<PackEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByNameOrDescription (string p_name);
}
}
