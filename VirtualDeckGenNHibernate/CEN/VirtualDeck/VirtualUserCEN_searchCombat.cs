
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


/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_searchCombat) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
public partial class VirtualUserCEN
{
public void SearchCombat (int p_user)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CEN.VirtualDeck_VirtualUser_searchCombat) ENABLED START*/

        // Write here your custom code...

        VirtualUserEN virtualUser = _IVirtualUserCAD.ReadOID (p_user);

        virtualUser.CombatStatus = Enumerated.VirtualDeck.CombatStatusEnum.Searching;
        _IVirtualUserCAD.Modify (virtualUser);

        /*PROTECTED REGION END*/
}
}
}
