
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_new_) ENABLED START*/
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class VirtualUserCEN
{
public int New_ (String p_pass, string p_userName, string p_email)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_new__customized) ENABLED START*/

        VirtualUserEN virtualUserEN = null;

        int oid;

        //Initialized VirtualUserEN
        virtualUserEN = new VirtualUserEN ();
        virtualUserEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        virtualUserEN.UserName = p_userName;

        virtualUserEN.Email = p_email;

        virtualUserEN.Description = "";

        virtualUserEN.Tokens = 0;

        virtualUserEN.Img = "usuario.png";

        virtualUserEN.CombatStatus = CombatStatusEnum.Inactive;
        //Call to VirtualUserCAD

        oid = _IVirtualUserCAD.New_ (virtualUserEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
