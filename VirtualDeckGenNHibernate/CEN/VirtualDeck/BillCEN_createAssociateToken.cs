
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Bill_createAssociateToken) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class BillCEN
{
public int CreateAssociateToken (int p_user, int p_tokenPack)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Bill_createAssociateToken_customized) ENABLED START*/

        BillEN billEN = null;

        int oid;

        //Initialized BillEN
        billEN = new BillEN ();
        billEN.Date = DateTime.Now;
        billEN.Amount = 1;

        if (p_user != -1) {
                billEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                billEN.User.Id = p_user;
        }


        if (p_tokenPack != -1) {
                billEN.TokenPack = new VirtualDeckGenNHibernate.EN.VirtualDeck.TokenPackEN ();
                billEN.TokenPack.Id = p_tokenPack;
        }

        //Call to BillCAD

        oid = _IBillCAD.CreateAssociateToken (billEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
