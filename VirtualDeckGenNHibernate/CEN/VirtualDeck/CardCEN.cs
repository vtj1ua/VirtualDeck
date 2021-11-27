

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class CardCEN
 *
 */
public partial class CardCEN
{
private ICardCAD _ICardCAD;

public CardCEN()
{
        this._ICardCAD = new CardCAD ();
}

public CardCEN(ICardCAD _ICardCAD)
{
        this._ICardCAD = _ICardCAD;
}

public ICardCAD get_ICardCAD ()
{
        return this._ICardCAD;
}

public int New_ (string p_name, string p_description, int p_price, string p_img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, int p_health, int p_attack, int p_defense, int p_speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum p_rarity, System.Collections.Generic.IList<int> p_attackMoves)
{
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
}

public void Modify (int p_Card_OID, string p_name, string p_description, int p_price, string p_img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, int p_health, int p_attack, int p_defense, int p_speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum p_rarity)
{
        CardEN cardEN = null;

        //Initialized CardEN
        cardEN = new CardEN ();
        cardEN.Id = p_Card_OID;
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
        //Call to CardCAD

        _ICardCAD.Modify (cardEN);
}

public void Destroy (int id
                     )
{
        _ICardCAD.Destroy (id);
}

public CardEN ReadOID (int id
                       )
{
        CardEN cardEN = null;

        cardEN = _ICardCAD.ReadOID (id);
        return cardEN;
}

public System.Collections.Generic.IList<CardEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CardEN> list = null;

        list = _ICardCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByType (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum ? p_type)
{
        return _ICardCAD.CardsByType (p_type);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum ? p_rarity)
{
        return _ICardCAD.CardsByRarity (p_rarity);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByNameOrDescription (string p_cardName)
{
        return _ICardCAD.CardsByNameOrDescription (p_cardName);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByPrice (int ? p_price)
{
        return _ICardCAD.CardsByPrice (p_price);
}
}
}
