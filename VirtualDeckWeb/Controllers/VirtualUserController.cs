using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckWeb.Assemblers;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Controllers
{
    public class VirtualUserController : BasicController
    {
        // GET: VirtualUser
        public ActionResult Index()
        {
            SessionInitialize();
            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            List<VirtualUserEN> virtualUserEN = virtualUserCEN.ReadAll(0, -1).ToList();
            IEnumerable<VirtualUserViewModel> model = new VirtualUserAssembler().ConvertListENToModel(virtualUserEN);
            SessionClose();
            return View(model);
        }

        // GET: VirtualUser/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(id);
            VirtualUserViewModel model = new VirtualUserAssembler().ConvertENToModelUI(virtualUserEN);
            SessionClose();
            return View(model);
        }
    }
}