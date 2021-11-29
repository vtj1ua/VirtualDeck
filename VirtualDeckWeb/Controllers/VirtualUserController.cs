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
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

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

        public ActionResult Edit()
        {
            SessionInitialize();
            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if(en != null)
            {
                VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(en.Id);
                VirtualUserViewModel model = new VirtualUserAssembler().ConvertENToModelUI(virtualUserEN);
                SessionClose();
                return View(model);
            }
            SessionClose();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(VirtualUserViewModel usu)
        {
            try
            {
                VirtualUserCEN cen = new VirtualUserCEN();
                switch (usu.CombatStatus)
                {
                    case 1:
                        cen.Modify(usu.Id, usu.Pass, usu.UserName, usu.Email, usu.Description, usu.Tokens, usu.Img, CombatStatusEnum.Inactive);
                        break;
                    case 2:
                        cen.Modify(usu.Id, usu.Pass, usu.UserName, usu.Email, usu.Description, usu.Tokens, usu.Img, CombatStatusEnum.Searching);
                        break;
                }

                IList<VirtualUserEN> vicen = cen.UsersByEmail(usu.Email);
                if (vicen.Count > 0)
                {
                    Session["user"] = vicen[0];
                }

                return RedirectToAction("Details", new { id = usu.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}