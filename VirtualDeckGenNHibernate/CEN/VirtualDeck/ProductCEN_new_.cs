
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_Product_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class ProductCEN
{
public int New_ (string p_name, string p_description, int p_price, string p_img)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_Product_new__customized) START*/

        ProductEN productEN = null;

        int oid;

        //Initialized ProductEN
        productEN = new ProductEN ();
        productEN.Name = p_name;

        productEN.Description = p_description;

        productEN.Price = p_price;

        productEN.Img = p_img;

        //Call to ProductCAD

        oid = _IProductCAD.New_ (productEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
