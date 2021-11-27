
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_UserPack_openPack) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class UserPackCP : BasicCP
{
public void OpenPack (int p_pack)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_UserPack_openPack) ENABLED START*/


        IUserPackCAD userPackCAD = null;
        UserPackCEN userPackCEN = null;

        try
        {
                SessionInitializeTransaction ();
                userPackCAD = new UserPackCAD (session);
                userPackCEN = new UserPackCEN (userPackCAD);

                UserCardCAD userCardCAD = new UserCardCAD (session);
                UserCardCEN userCardCEN = new UserCardCEN (userCardCAD);

                UserPackEN userPackEN = userPackCEN.ReadOID (p_pack);

                int userId = userPackEN.User.Id;

                IList<UserCardEN> packCards = userPackEN.UserCards;
                foreach (UserCardEN card in packCards) {
                        userCardCEN.AssignUser (card.Id, userId);
                }

                //Desasignar el pack o el destroy ya lo desasigna (deberia)?
                userPackCEN.Destroy (p_pack);

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

        /*PROTECTED REGION END*/
}
}
}
