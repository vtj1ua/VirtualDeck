

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
 *      Definition of the class BillCEN
 *
 */
public partial class BillCEN
{
private IBillCAD _IBillCAD;

public BillCEN()
{
        this._IBillCAD = new BillCAD ();
}

public BillCEN(IBillCAD _IBillCAD)
{
        this._IBillCAD = _IBillCAD;
}

public IBillCAD get_IBillCAD ()
{
        return this._IBillCAD;
}

public void Modify (int p_Bill_OID, Nullable<DateTime> p_date, int p_amount)
{
        BillEN billEN = null;

        //Initialized BillEN
        billEN = new BillEN ();
        billEN.Id = p_Bill_OID;
        billEN.Date = p_date;
        billEN.Amount = p_amount;
        //Call to BillCAD

        _IBillCAD.Modify (billEN);
}

public void Destroy (int id
                     )
{
        _IBillCAD.Destroy (id);
}

public BillEN ReadOID (int id
                       )
{
        BillEN billEN = null;

        billEN = _IBillCAD.ReadOID (id);
        return billEN;
}

public System.Collections.Generic.IList<BillEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BillEN> list = null;

        list = _IBillCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> BillsByUser (int p_user)
{
        return _IBillCAD.BillsByUser (p_user);
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> CardBillsByUser (int p_user)
{
        return _IBillCAD.CardBillsByUser (p_user);
}
}
}
