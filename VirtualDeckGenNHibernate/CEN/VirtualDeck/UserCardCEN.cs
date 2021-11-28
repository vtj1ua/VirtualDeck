

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
 *      Definition of the class UserCardCEN
 *
 */
public partial class UserCardCEN
{
private IUserCardCAD _IUserCardCAD;

public UserCardCEN()
{
        this._IUserCardCAD = new UserCardCAD ();
}

public UserCardCEN(IUserCardCAD _IUserCardCAD)
{
        this._IUserCardCAD = _IUserCardCAD;
}

public IUserCardCAD get_IUserCardCAD ()
{
        return this._IUserCardCAD;
}

public void Modify (int p_UserCard_OID, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, int p_speed, int p_defense, int p_attack, int p_health, int p_level, int p_experience, string p_name, string p_img, Nullable<DateTime> p_purchaseDate, double p_quality)
{
        UserCardEN userCardEN = null;

        //Initialized UserCardEN
        userCardEN = new UserCardEN ();
        userCardEN.Id = p_UserCard_OID;
        userCardEN.Type = p_type;
        userCardEN.Rarity = p_rarity;
        userCardEN.Speed = p_speed;
        userCardEN.Defense = p_defense;
        userCardEN.Attack = p_attack;
        userCardEN.Health = p_health;
        userCardEN.Level = p_level;
        userCardEN.Experience = p_experience;
        userCardEN.Name = p_name;
        userCardEN.Img = p_img;
        userCardEN.PurchaseDate = p_purchaseDate;
        userCardEN.Quality = p_quality;
        //Call to UserCardCAD

        _IUserCardCAD.Modify (userCardEN);
}

public UserCardEN ReadOID (int id
                           )
{
        UserCardEN userCardEN = null;

        userCardEN = _IUserCardCAD.ReadOID (id);
        return userCardEN;
}

public System.Collections.Generic.IList<UserCardEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserCardEN> list = null;

        list = _IUserCardCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByName (int p_user, string p_name)
{
        return _IUserCardCAD.UserCardsByName (p_user, p_name);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByBaseCard (int p_user, int p_baseCard)
{
        return _IUserCardCAD.UserCardsByBaseCard (p_user, p_baseCard);
}
public void AssignUser (int p_UserCard_OID, int p_user_OID)
{
        //Call to UserCardCAD

        _IUserCardCAD.AssignUser (p_UserCard_OID, p_user_OID);
}
public void DessasignUser (int p_UserCard_OID, int p_user_OID)
{
        //Call to UserCardCAD

        _IUserCardCAD.DessasignUser (p_UserCard_OID, p_user_OID);
}
public void AssignPack (int p_UserCard_OID, int p_userPack_OID)
{
        //Call to UserCardCAD

        _IUserCardCAD.AssignPack (p_UserCard_OID, p_userPack_OID);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByUser (int p_user)
{
        return _IUserCardCAD.UserCardsByUser (p_user);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsNotInTradeByUser (int p_user)
{
        return _IUserCardCAD.UserCardsNotInTradeByUser (p_user);
}
}
}
