
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Card_getUserRecommendedCards) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CardCP : BasicCP
{
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> GetUserRecommendedCards (int p_userId)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Card_getUserRecommendedCards) ENABLED START*/

        Random rnd = new Random ();

        IList<CardEN> recommendedCards = new List<CardEN>();
        ICardCAD cardCAD = null;
        CardCEN cardCEN = null;

        try
        {
                SessionInitializeTransaction ();
                cardCAD = new CardCAD (session);
                cardCEN = new  CardCEN (cardCAD);

                BillCAD billCAD = new BillCAD (session);
                BillCEN billCEN = new BillCEN (billCAD);

                CardTypeEnum cardTypes = CardTypeEnum.None;
                IList<BillEN> cardBills = billCEN.CardBillsByUser (p_userId);

                if (cardBills.Count > 0) {
                        for (int i = 0; i < 5 && i < cardBills.Count; ++i) {
                                CardEN card = cardCEN.ReadOID (cardBills[rnd.Next(0, cardBills.Count)].Product.Id);
                                cardTypes |= card.Type;
                        }
                }
                else
                        cardTypes = CardTypeEnum.All;

                IList<CardEN> cards = cardCEN.CardsByTypeAndRarity (cardTypes,
                        RarityEnum.All);

                if (cards.Count == 0)
                    cards = cardCEN.ReadAll(0, -1);

                for (int i = 0; i < 5 && cards.Count > 0; ++i) {
                        int index = rnd.Next (0, cards.Count);
                        recommendedCards.Add (cards [index]);

                        CardEN aux = cards [cards.Count - 1];
                        cards [cards.Count - 1] = cards [index];
                        cards [index] = aux;

                        cards.RemoveAt (cards.Count - 1);
                }

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }

        return recommendedCards;

        /*PROTECTED REGION END*/
}
}
}
