
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Card_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class CardCEN
{
public int New_ (string p_name, string p_description, int p_price, string p_img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, int p_health, int p_attack, int p_defense, int p_speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, System.Collections.Generic.IList<int> p_attackMoves)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Card_new__customized) ENABLED START*/

        CardEN cardEN = null;

        int oid;

        //Initialized CardEN
        cardEN = new CardEN ();
        cardEN.Name = p_name;

        cardEN.Description = p_description;

        cardEN.Price = p_price;

        cardEN.Img = p_img;

        cardEN.Type = p_type;

        cardEN.Health = p_health;

        cardEN.Attack = p_attack;

        cardEN.Defense = p_defense;

        cardEN.Speed = p_speed;

        cardEN.Rarity = p_rarity;

        cardEN.RegistryDate = DateTime.Now;


        cardEN.AttackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        if (p_attackMoves != null) {
                foreach (int item in p_attackMoves) {
                        VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN en = new VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN ();
                        en.Id = item;
                        cardEN.AttackMoves.Add (en);
                }
        }

        else{
                cardEN.AttackMoves = new System.Collections.Generic.List<VirtualDeckGenNHibernate.EN.VirtualDeck.AttackMoveEN>();
        }

        //Call to CardCAD

        oid = _ICardCAD.New_ (cardEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
