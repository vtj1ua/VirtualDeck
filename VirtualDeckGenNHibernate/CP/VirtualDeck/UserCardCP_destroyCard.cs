
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



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_UserCard_destroyCard) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class UserCardCP : BasicCP
{
public void DestroyCard (int p_card)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_UserCard_destroyCard) ENABLED START*/

        IUserCardCAD userCardCAD = null;
        UserCardCEN userCardCEN = null;

        try
        {
                SessionInitializeTransaction ();
                userCardCAD = new UserCardCAD (session);
                userCardCEN = new UserCardCEN (userCardCAD);

                VirtualUserCAD virtualUserCAD = new VirtualUserCAD (session);

                UserCardEN userCardEN = userCardCEN.ReadOID (p_card);
                CardEN baseCard = userCardEN.Card;
                VirtualUserEN user = userCardEN.User;

                if (user != null) {
                        int amount = (int)(baseCard.Price * 0.25f);
                        user.Tokens += amount;

                        virtualUserCAD.Modify (user);
                }

                userCardCAD.DestroyCard (p_card);


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
