
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Bill_createAssociateProduct) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class BillCP : BasicCP
{
public VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN CreateAssociateProduct (int p_amount, int p_user)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Bill_createAssociateProduct) ENABLED START*/

        IBillCAD billCAD = null;
        BillCEN billCEN = null;

        VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN result = null;


        try
        {
                SessionInitializeTransaction ();
                billCAD = new BillCAD (session);
                billCEN = new  BillCEN (billCAD);




                int oid;
                //Initialized BillEN
                BillEN billEN;
                billEN = new BillEN ();


                billEN.Amount = p_amount;


                if (p_user != -1) {
                        billEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                        billEN.User.Id = p_user;
                }

                //Call to BillCAD

                oid = billCAD.CreateAssociateProduct (billEN);
                result = billCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
