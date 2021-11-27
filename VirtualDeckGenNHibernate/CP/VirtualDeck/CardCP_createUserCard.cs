
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Card_createUserCard) ENABLED START*/
using System.Linq;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CardCP : BasicCP
{
public int CreateUserCard (int p_card, int p_seed)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Card_createUserCard) ENABLED START*/

        int userCardID = -1;

        Random rnd = new Random (p_seed);
        ICardCAD cardCAD = null;
        CardCEN cardCEN = null;

        try
        {
                SessionInitializeTransaction ();
                cardCAD = new CardCAD (session);
                cardCEN = new CardCEN (cardCAD);

                CardEN baseCard = cardCEN.ReadOID (p_card);
                //Anadir solo determinados ataques despues
                IList<AttackMoveEN> baseCardAttacks = baseCard.AttackMoves;
                List<int> attacksIDs = baseCardAttacks.Select ((item) => item.Id).ToList ();

                UserCardCAD userCardCAD = new UserCardCAD (session);
                UserCardCEN userCardCEN = new UserCardCEN (userCardCAD);

                //Anadir valores aleatorios a las estadisticas
                CardTypeEnum type = baseCard.Type;
                CardRarityEnum rarity = baseCard.Rarity;
                int health = baseCard.Health + rnd.Next (-10, 10);
                int attack = baseCard.Attack + rnd.Next (-10, 10);
                int defense = baseCard.Defense + rnd.Next (-10, 10);
                int speed = baseCard.Speed + rnd.Next (-10, 10);
                string name = baseCard.Name;
                string image = baseCard.Img;

                userCardID = userCardCEN.New_ (type, rarity, speed, defense, attack, health, name, image, attacksIDs, p_card);

                // Write here your custom transaction ...

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

        return userCardID;
        /*PROTECTED REGION END*/
}
}
}
