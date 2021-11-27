
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface ICardCAD
{
CardEN ReadOIDDefault (int id
                       );

void ModifyDefault (CardEN card);

System.Collections.Generic.IList<CardEN> ReadAllDefault (int first, int size);



int New_ (CardEN card);

void Modify (CardEN card);


void Destroy (int id
              );



CardEN ReadOID (int id
                );


System.Collections.Generic.IList<CardEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByType (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum ? p_type);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum ? p_rarity);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByNameOrDescription (string p_cardName);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByPrice (int ? p_price);
}
}
