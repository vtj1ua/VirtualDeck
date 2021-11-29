using VirtualDeck.Controllers;
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

        // GET: VirtualUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirtualUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VirtualUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VirtualUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VirtualUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VirtualUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
