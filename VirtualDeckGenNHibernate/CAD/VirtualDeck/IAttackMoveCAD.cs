
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IAttackMoveCAD
{
AttackMoveEN ReadOIDDefault (int id
                             );

void ModifyDefault (AttackMoveEN attackMove);

System.Collections.Generic.IList<AttackMoveEN> ReadAllDefault (int first, int size);



int New_ (AttackMoveEN attackMove);

void Modify (AttackMoveEN attackMove);


void Destroy (int id
              );


AttackMoveEN ReadOID (int id
                      );


System.Collections.Generic.IList<AttackMoveEN> ReadAll (int first, int size);
}
}
