
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


System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.BillEN> CardBillsByUser (int p_user);


void AssignNotification (int p_Bill_OID, int p_notification_OID);
}
}
