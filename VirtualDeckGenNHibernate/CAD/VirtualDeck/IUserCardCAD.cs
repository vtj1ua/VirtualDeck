
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IUserCardCAD
{
UserCardEN ReadOIDDefault (int id
                           );

void ModifyDefault (UserCardEN userCard);

System.Collections.Generic.IList<UserCardEN> ReadAllDefault (int first, int size);



int New_ (UserCardEN userCard);

void Modify (UserCardEN userCard);


void DestroyCard (int id
                  );


UserCardEN ReadOID (int id
                    );


System.Collections.Generic.IList<UserCardEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByName (int p_user, string p_name);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByBaseCard (int p_user, int p_baseCard);


void AssignUser (int p_UserCard_OID, int p_user_OID);

void DessasignUser (int p_UserCard_OID, int p_user_OID);

void AssignPack (int p_UserCard_OID, int p_userPack_OID);

System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsByUser (int p_user);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserCardEN> UserCardsNotInTradeByUser (int p_user);
}
}
