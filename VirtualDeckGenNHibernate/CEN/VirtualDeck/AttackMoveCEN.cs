

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
 *      Definition of the class AttackMoveCEN
 *
 */
public partial class AttackMoveCEN
{
private IAttackMoveCAD _IAttackMoveCAD;

public AttackMoveCEN()
{
        this._IAttackMoveCAD = new AttackMoveCAD ();
}

public AttackMoveCEN(IAttackMoveCAD _IAttackMoveCAD)
{
        this._IAttackMoveCAD = _IAttackMoveCAD;
}

public IAttackMoveCAD get_IAttackMoveCAD ()
{
        return this._IAttackMoveCAD;
}

public int New_ (string p_name, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, string p_description)
{
        AttackMoveEN attackMoveEN = null;
        int oid;

        //Initialized AttackMoveEN
        attackMoveEN = new AttackMoveEN ();
        attackMoveEN.Name = p_name;

        attackMoveEN.Type = p_type;

        attackMoveEN.Description = p_description;

        //Call to AttackMoveCAD

        oid = _IAttackMoveCAD.New_ (attackMoveEN);
        return oid;
}

public void Modify (int p_AttackMove_OID, string p_name, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum p_type, string p_description)
{
        AttackMoveEN attackMoveEN = null;

        //Initialized AttackMoveEN
        attackMoveEN = new AttackMoveEN ();
        attackMoveEN.Id = p_AttackMove_OID;
        attackMoveEN.Name = p_name;
        attackMoveEN.Type = p_type;
        attackMoveEN.Description = p_description;
        //Call to AttackMoveCAD

        _IAttackMoveCAD.Modify (attackMoveEN);
}

public void Destroy (int id
                     )
{
        _IAttackMoveCAD.Destroy (id);
}

public AttackMoveEN ReadOID (int id
                             )
{
        AttackMoveEN attackMoveEN = null;

        attackMoveEN = _IAttackMoveCAD.ReadOID (id);
        return attackMoveEN;
}

public System.Collections.Generic.IList<AttackMoveEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AttackMoveEN> list = null;

        list = _IAttackMoveCAD.ReadAll (first, size);
        return list;
}
}
}
