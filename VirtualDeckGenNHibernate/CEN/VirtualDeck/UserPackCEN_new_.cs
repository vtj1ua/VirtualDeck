
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_UserPack_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class UserPackCEN
{
public int New_ (int p_user, System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> p_userCards, int p_pack, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.RarityEnum p_rarity, string p_name)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_UserPack_new__customized) ENABLED START*/

        UserPackEN userPackEN = null;

        int oid;

        //Initialized UserPackEN
        userPackEN = new UserPackEN ();
        userPackEN.Rarity = p_rarity;
        userPackEN.Name = p_name;
        userPackEN.PurchaseDate = DateTime.Now;


        if (p_user != -1) {
                userPackEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                userPackEN.User.Id = p_user;
        }

        userPackEN.UserCards = p_userCards;


        if (p_pack != -1) {
                userPackEN.Pack = new VirtualDeckGenNHibernate.EN.VirtualDeck.PackEN ();
                userPackEN.Pack.Id = p_pack;
        }

        //Call to UserPackCAD

        oid = _IUserPackCAD.New_ (userPackEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
