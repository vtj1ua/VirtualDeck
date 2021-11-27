

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
 *      Definition of the class ProductCEN
 *
 */
public partial class ProductCEN
{
private IProductCAD _IProductCAD;

public ProductCEN()
{
        this._IProductCAD = new ProductCAD ();
}

public ProductCEN(IProductCAD _IProductCAD)
{
        this._IProductCAD = _IProductCAD;
}

public IProductCAD get_IProductCAD ()
{
        return this._IProductCAD;
}

public int New_ (string p_name, string p_description, int p_price, string p_img, Nullable<DateTime> p_registryDate)
{
        ProductEN productEN = null;
        int oid;

        //Initialized ProductEN
        productEN = new ProductEN ();
        productEN.Name = p_name;

        productEN.Description = p_description;

        productEN.Price = p_price;

        productEN.Img = p_img;

        productEN.RegistryDate = p_registryDate;

        //Call to ProductCAD

        oid = _IProductCAD.New_ (productEN);
        return oid;
}

public void Modify (int p_Product_OID, string p_name, string p_description, int p_price, string p_img, Nullable<DateTime> p_registryDate)
{
        ProductEN productEN = null;

        //Initialized ProductEN
        productEN = new ProductEN ();
        productEN.Id = p_Product_OID;
        productEN.Name = p_name;
        productEN.Description = p_description;
        productEN.Price = p_price;
        productEN.Img = p_img;
        productEN.RegistryDate = p_registryDate;
        //Call to ProductCAD

        _IProductCAD.Modify (productEN);
}

public void Destroy (int id
                     )
{
        _IProductCAD.Destroy (id);
}

public ProductEN ReadOID (int id
                          )
{
        ProductEN productEN = null;

        productEN = _IProductCAD.ReadOID (id);
        return productEN;
}

public System.Collections.Generic.IList<ProductEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductEN> list = null;

        list = _IProductCAD.ReadAll (first, size);
        return list;
}
}
}
