

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

public void Modify (int p_Card_OID, string p_name, string p_description, int p_price, string p_img, Nullable<DateTime> p_registryDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, int p_health, int p_attack, int p_defense, int p_speed, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity)
{
        CardEN cardEN = null;

        //Initialized CardEN
        cardEN = new CardEN ();
        cardEN.Id = p_Card_OID;
        cardEN.Name = p_name;
        cardEN.Description = p_description;
        cardEN.Price = p_price;
        cardEN.Img = p_img;
        cardEN.RegistryDate = p_registryDate;
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
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        return _ICardCAD.CardsByRarity (p_rarity);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByNameOrDescription (string p_cardName)
{
        return _ICardCAD.CardsByNameOrDescription (p_cardName);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByPrice (int? p_min_price, int ? p_max_price)
{
        return _ICardCAD.CardsByPrice (p_min_price, p_max_price);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByMaxRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        return _ICardCAD.CardsByMaxRarity (p_rarity);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByTypeAndRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum? p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        return _ICardCAD.CardsByTypeAndRarity (p_type, p_rarity);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByRegistryDate ()
{
        return _ICardCAD.CardsByRegistryDate ();
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.CardEN> CardsByAllFilters (string p_name, int? p_min_price, int? p_max_price, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum? p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        return _ICardCAD.CardsByAllFilters (p_name, p_min_price, p_max_price, p_type, p_rarity);
}
}
}
