

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
 *      Definition of the class UserPackCEN
 *
 */
public partial class UserPackCEN
{
private IUserPackCAD _IUserPackCAD;

public UserPackCEN()
{
        this._IUserPackCAD = new UserPackCAD ();
}

public UserPackCEN(IUserPackCAD _IUserPackCAD)
{
        this._IUserPackCAD = _IUserPackCAD;
}

public IUserPackCAD get_IUserPackCAD ()
{
        return this._IUserPackCAD;
}

public void Modify (int p_UserPack_OID, Nullable<DateTime> p_purchaseDate, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.PackTypeEnum p_type)
{
        UserPackEN userPackEN = null;

        //Initialized UserPackEN
        userPackEN = new UserPackEN ();
        userPackEN.Id = p_UserPack_OID;
        userPackEN.PurchaseDate = p_purchaseDate;
        userPackEN.Type = p_type;
        //Call to UserPackCAD

        _IUserPackCAD.Modify (userPackEN);
}

public void Destroy (int id
                     )
{
        _IUserPackCAD.Destroy (id);
}

public UserPackEN ReadOID (int id
                           )
{
        UserPackEN userPackEN = null;

        userPackEN = _IUserPackCAD.ReadOID (id);
        return userPackEN;
}

public System.Collections.Generic.IList<UserPackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserPackEN> list = null;

        list = _IUserPackCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacksByUser (int p_user)
{
        return _IUserPackCAD.UserPacksByUser (p_user);
}
}
}
