
using System;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckGenNHibernate.CAD.VirtualDeck
{
public partial interface IBillCAD
{
BillEN ReadOIDDefault (int id
                       );

void ModifyDefault (BillEN bill);

System.Collections.Generic.IList<BillEN> ReadAllDefault (int first, int size);



void Modify (BillEN bill);


void Destroy (int id
              );


int CreateAssociateToken (BillEN bill);

int CreateAssociateProduct (BillEN bill);

BillEN ReadOID (int id
                );


System.Collections.Generic.IList<BillEN> ReadAll (int first, int size);


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> BillsByUser (int p_user);
}
}
