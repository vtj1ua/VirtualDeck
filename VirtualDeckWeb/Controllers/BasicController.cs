﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.Exceptions;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


public class BasicController: Controller
{
    public class BasicController : Controller
    {
protected ISession session;

protected BasicController()
{
}

protected void SessionInitialize ()
{
        if (session == null) {
                session = NHibernateHelper.OpenSession ();
        }
}


protected void SessionClose ()
{
        if (session != null && session.IsOpen) {
                session.Close ();
                session.Dispose ();
                session = null;
        }
}
}

