
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Bill_createAssociateProduct) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class BillCEN
{
public int CreateAssociateProduct (int p_user, int p_product, int p_amount)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Bill_createAssociateProduct_customized) ENABLED START*/

        BillEN billEN = null;

        int oid;

        //Initialized BillEN
        billEN = new BillEN ();
        billEN.Amount = p_amount;
        billEN.Date = DateTime.Now;

        if (p_product != -1) {
                billEN.Product = new VirtualDeckGenNHibernate.EN.VirtualDeck.ProductEN ();
                billEN.Product.Id = p_product;
        }

        if (p_user != -1) {
                billEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                billEN.User.Id = p_user;
        }

        //Call to BillCAD

        oid = _IBillCAD.CreateAssociateProduct (billEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
