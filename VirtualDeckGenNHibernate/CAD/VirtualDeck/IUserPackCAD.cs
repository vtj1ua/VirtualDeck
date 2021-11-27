
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IUserPackCAD
{
UserPackEN ReadOIDDefault (int id
                           );

void ModifyDefault (UserPackEN userPack);

System.Collections.Generic.IList<UserPackEN> ReadAllDefault (int first, int size);



int New_ (UserPackEN userPack);

void Modify (UserPackEN userPack);


void Destroy (int id
              );


void OpenPack (int id
               );


UserPackEN ReadOID (int id
                    );


System.Collections.Generic.IList<UserPackEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.UserPackEN> UserPacksByUser (int p_user);
}
}
