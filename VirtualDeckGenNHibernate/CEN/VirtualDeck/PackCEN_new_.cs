
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Pack_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class PackCEN
{
public int New_ (string p_name, string p_description, int p_price, string p_img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, int p_maxNumCards, int p_minNumCards, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_cardTypes, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_cardRarities)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Pack_new__customized) ENABLED START*/

        PackEN packEN = null;

        int oid;

        if (p_cardTypes == Enumerated.VirtualDeck.CardTypeEnum.None)
                throw new Exception ("El sobre debe contener algun tipo  de carta");
        if (p_cardRarities == Enumerated.VirtualDeck.RarityEnum.None)
                throw new Exception ("El sobre debe contener alguna rareza de cartas");

        //Initialized PackEN
        packEN = new PackEN ();
        packEN.Name = p_name;

        packEN.Description = p_description;

        packEN.Price = p_price;

        packEN.Img = p_img;

        packEN.Rarity = p_rarity;

        packEN.MaxNumCards = p_maxNumCards;

        packEN.MinNumCards = p_minNumCards;

        packEN.CardTypes = p_cardTypes;

        packEN.CardRarities = p_cardRarities;

        packEN.RegistryDate = DateTime.Now;
        //Call to PackCAD

        oid = _IPackCAD.New_ (packEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
