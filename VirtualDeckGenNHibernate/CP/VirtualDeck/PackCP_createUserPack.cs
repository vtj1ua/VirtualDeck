
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Pack_createUserPack) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class PackCP : BasicCP
{
public int CreateUserPack (int p_pack, int p_user, int p_seed)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Pack_createUserPack) ENABLED START*/
        IPackCAD packCAD = null;
        PackCEN packCEN = null;

        Random rnd = new Random (p_seed);
        int userPackID = -1;

        try
        {
                SessionInitializeTransaction ();
                packCAD = new PackCAD (session);
                packCEN = new PackCEN (packCAD);

                CardCAD cardCAD = new CardCAD (session);
                CardCEN cardCEN = new CardCEN (cardCAD);
                CardCP cardCP = new CardCP (session);

                UserCardCAD userCardCAD = new UserCardCAD (session);
                UserCardCEN userCardCEN = new UserCardCEN (userCardCAD);

                UserPackCAD userPackCAD = new UserPackCAD (session);
                UserPackCEN userPackCEN = new UserPackCEN (userPackCAD);

                //PackCAD

                PackEN packEN = packCEN.ReadOID (p_pack);
                int numCards = rnd.Next (packEN.MinNumCards, packEN.MaxNumCards + 1);

                //Cambiar para que genere cartas dependiendo del tipo
                IList<CardEN> cards = cardCEN.ReadAll (0, 50); //Leer hasta el numero maximo de cartas
                List<UserCardEN> userCards = new List<UserCardEN>();

                for (int i = 0; i < numCards; ++i) {
                        int index = rnd.Next (0, cards.Count);
                        CardEN currentCard = cards [index];

                        int userCardID = cardCP.CreateUserCard (currentCard.Id, rnd.Next ());
                        userCards.Add (userCardCEN.ReadOID (userCardID));
                }

                //Deberia tener tambien la foto del sobre
                userPackID = userPackCEN.New_ (packEN.Type, p_user, userCards, p_pack);

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

        return userPackID;


        /*PROTECTED REGION END*/
}
}
}
