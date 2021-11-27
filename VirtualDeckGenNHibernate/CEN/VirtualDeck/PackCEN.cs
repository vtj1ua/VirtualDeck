

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
 *      Definition of the class PackCEN
 *
 */
public partial class PackCEN
{
private IPackCAD _IPackCAD;

public PackCEN()
{
        this._IPackCAD = new PackCAD ();
}

public PackCEN(IPackCAD _IPackCAD)
{
        this._IPackCAD = _IPackCAD;
}

public IPackCAD get_IPackCAD ()
{
        return this._IPackCAD;
}

public void Modify (int p_Pack_OID, string p_name, string p_description, int p_price, string p_img, Nullable<DateTime> p_registryDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, int p_maxNumCards, int p_minNumCards, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_cardTypes, System.Collections.Generic.IList<float> p_cardsRarityProbabilities)
{
        PackEN packEN = null;

        //Initialized PackEN
        packEN = new PackEN ();
        packEN.Id = p_Pack_OID;
        packEN.Name = p_name;
        packEN.Description = p_description;
        packEN.Price = p_price;
        packEN.Img = p_img;
        packEN.RegistryDate = p_registryDate;
        packEN.Rarity = p_rarity;
        packEN.MaxNumCards = p_maxNumCards;
        packEN.MinNumCards = p_minNumCards;
        packEN.CardTypes = p_cardTypes;
        packEN.CardsRarityProbabilities = p_cardsRarityProbabilities;
        //Call to PackCAD

        _IPackCAD.Modify (packEN);
}

public void Destroy (int id
                     )
{
        _IPackCAD.Destroy (id);
}

public PackEN ReadOID (int id
                       )
{
        PackEN packEN = null;

        packEN = _IPackCAD.ReadOID (id);
        return packEN;
}

public System.Collections.Generic.IList<PackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PackEN> list = null;

        list = _IPackCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByRarity (VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum ? p_rarity)
{
        return _IPackCAD.PacksByRarity (p_rarity);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN> PacksByNameOrDescription (string p_name)
{
        return _IPackCAD.PacksByNameOrDescription (p_name);
}
}
}
