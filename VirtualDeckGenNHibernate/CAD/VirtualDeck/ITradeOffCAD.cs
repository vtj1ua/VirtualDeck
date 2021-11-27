
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
}
}
