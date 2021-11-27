
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface ICombatCAD
{
CombatEN ReadOIDDefault (int id
                         );

void ModifyDefault (CombatEN combat);

System.Collections.Generic.IList<CombatEN> ReadAllDefault (int first, int size);



int New_ (CombatEN combat);

void Modify (CombatEN combat);


void Destroy (int id
              );


CombatEN ReadOID (int id
                  );


System.Collections.Generic.IList<CombatEN> ReadAll (int first, int size);
}
}
