

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
 *      Definition of the class TokenPackCEN
 *
 */
public partial class TokenPackCEN
{
private ITokenPackCAD _ITokenPackCAD;

public TokenPackCEN()
{
        this._ITokenPackCAD = new TokenPackCAD ();
}

public TokenPackCEN(ITokenPackCAD _ITokenPackCAD)
{
        this._ITokenPackCAD = _ITokenPackCAD;
}

public ITokenPackCAD get_ITokenPackCAD ()
{
        return this._ITokenPackCAD;
}

public int New_ (string p_name, double p_price, int p_tokens)
{
        TokenPackEN tokenPackEN = null;
        int oid;

        //Initialized TokenPackEN
        tokenPackEN = new TokenPackEN ();
        tokenPackEN.Name = p_name;

        tokenPackEN.Price = p_price;

        tokenPackEN.Tokens = p_tokens;

        //Call to TokenPackCAD

        oid = _ITokenPackCAD.New_ (tokenPackEN);
        return oid;
}

public void Modify (int p_TokenPack_OID, string p_name, double p_price, int p_tokens)
{
        TokenPackEN tokenPackEN = null;

        //Initialized TokenPackEN
        tokenPackEN = new TokenPackEN ();
        tokenPackEN.Id = p_TokenPack_OID;
        tokenPackEN.Name = p_name;
        tokenPackEN.Price = p_price;
        tokenPackEN.Tokens = p_tokens;
        //Call to TokenPackCAD

        _ITokenPackCAD.Modify (tokenPackEN);
}

public void Destroy (int id
                     )
{
        _ITokenPackCAD.Destroy (id);
}

public TokenPackEN ReadOID (int id
                            )
{
        TokenPackEN tokenPackEN = null;

        tokenPackEN = _ITokenPackCAD.ReadOID (id);
        return tokenPackEN;
}

public System.Collections.Generic.IList<TokenPackEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TokenPackEN> list = null;

        list = _ITokenPackCAD.ReadAll (first, size);
        return list;
}
}
}
