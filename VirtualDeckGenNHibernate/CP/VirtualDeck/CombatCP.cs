
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using VirtualDeckGenNHibernate.Exceptions;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;



namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class CombatCP : BasicCP
{
public CombatCP() : base ()
{
}

public CombatCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
