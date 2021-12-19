
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface ITradeOffCAD
{
TradeOffEN ReadOIDDefault (int id
                           );

void ModifyDefault (TradeOffEN tradeOff);

System.Collections.Generic.IList<TradeOffEN> ReadAllDefault (int first, int size);



void Modify (TradeOffEN tradeOff);


void Destroy (int id
              );



TradeOffEN ReadOID (int id
                    );


System.Collections.Generic.IList<TradeOffEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradesByCardName (string p_cardName);


int Publish (TradeOffEN tradeOff);

void AssignExchanger (int p_TradeOff_OID, int p_exchanger_OID);

void AssignGivenUserCard (int p_TradeOff_OID, int p_givenUserCard_OID);

void AssignNotification (int p_TradeOff_OID, System.Collections.Generic.IList<int> p_notifications_OIDs);

System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradesPendingAndNotFromUser ();


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.TradeOffEN> TradesPending ();
}
}
