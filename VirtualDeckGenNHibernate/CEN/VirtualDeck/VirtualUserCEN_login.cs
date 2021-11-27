
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class VirtualUserCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_login) ENABLED START*/
        string result = null;

        IList<VirtualUserEN> virtualUsers = _IVirtualUserCAD.UsersByEmail (p_email);

        if (virtualUsers.Count > 0) {
                VirtualUserEN en = virtualUsers [0];

                if (en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                        result = this.GetToken (en.Id);
        }

        return result;
        /*PROTECTED REGION END*/
}
}
}
