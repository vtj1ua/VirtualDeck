
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
                List<int> attacks = new List<int>();
                int numAttacks = rnd.Next (1, attacksIDs.Count + 1);

                UserCardCAD userCardCAD = new UserCardCAD (session);
                UserCardCEN userCardCEN = new UserCardCEN (userCardCAD);

                //Anadir valores aleatorios a las estadisticas
                CardTypeEnum type = baseCard.Type;
                RarityEnum rarity = baseCard.Rarity;
                int minRange = 0;
                int maxRange = 0;
                switch (rarity) {
                case RarityEnum.Basic: minRange = -5; maxRange = 5; break;

                case RarityEnum.Common: minRange = 0; maxRange = 10; break;

                case RarityEnum.Uncommon: minRange = 0; maxRange = 20; break;

                case RarityEnum.Rare: minRange = 0; maxRange = 25; break;

                case RarityEnum.Epic: minRange = 0; maxRange = 35; break;

                case RarityEnum.Legendary: minRange = 0; maxRange = 45; break;

                case RarityEnum.Mythical: minRange = 0; maxRange = 55; break;
                }

                int health = baseCard.Health + rnd.Next (minRange, maxRange + 1);
                int attack = baseCard.Attack + rnd.Next (minRange, maxRange + 1);
                int defense = baseCard.Defense + rnd.Next (minRange, maxRange + 1);
                int speed = baseCard.Speed + rnd.Next (minRange, maxRange + 1);
                double quality = rnd.NextDouble ();
                string name = baseCard.Name;
                string image = baseCard.Img;

                while (numAttacks > 0 && attacksIDs.Count > 0) {
                        int index = rnd.Next (0, attacksIDs.Count);
                        attacks.Add (attacksIDs [index]);
                        attacksIDs.RemoveAt (index);

                        --numAttacks;
                }

                userCardID = userCardCEN.New_ (type, rarity, speed, defense, attack, health, name, image, attacks, p_card, quality);

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
