
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_UserCard_new_) ENABLED START*/

/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class UserCardCEN
{
public int New_ (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, int p_speed, int p_defense, int p_attack, int p_health, string p_name, string p_img, System.Collections.Generic.IList<int> p_attackMoves, int p_card)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_UserCard_new__customized) ENABLED START*/

        UserCardEN userCardEN = null;

        int oid;

        //Initialized UserCardEN
        userCardEN = new UserCardEN ();
        userCardEN.Type = p_type;

        userCardEN.Rarity = p_rarity;

        userCardEN.Speed = p_speed;

        userCardEN.Defense = p_defense;

        userCardEN.Attack = p_attack;

        userCardEN.Health = p_health;

        userCardEN.Name = p_name;

        userCardEN.Img = p_img;

        userCardEN.PurchaseDate = DateTime.Now;

        userCardEN.Experience = 0;

        userCardEN.Level = 0;

        userCardEN.AttackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        if (p_attackMoves != null) {
                foreach (int item in p_attackMoves) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                        en.Id = item;
                        userCardEN.AttackMoves.Add (en);
                }
        }

        else{
                userCardEN.AttackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        }


        if (p_card != -1) {
                userCardEN.Card = new VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN ();
                userCardEN.Card.Id = p_card;
        }

        //Call to UserCardCAD

        oid = _IUserCardCAD.New_ (userCardEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
