using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Assemblers;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Controllers
{
    public class PackController : BasicController
    {
        // GET: Pack
        public ActionResult Index()
        {
            SessionInitialize();
            PackCAD packcad = new PackCAD(session);
            PackCEN packcen = new PackCEN(packcad);
            IList<PackEN> packs = packcen.ReadAll(0, -1);
            IEnumerable<PackViewModel> listaPacks = new PackAssembler().ConvertListENToModel(packs).ToList();
            SessionClose();
            return View(listaPacks);
        }

        // GET: Pack/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PackCAD packCAD = new PackCAD(session);
            PackCEN packCEN = new PackCEN(packCAD);
            PackEN packEN = packCEN.ReadOID(id);
            PackViewModel model = new PackAssembler().ConvertENToModelUI(packEN);
            SessionClose();
            return View(model);
        }

        // GET: Pack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pack/Create
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

        // GET: Pack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pack/Edit/5
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

        // GET: Pack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pack/Delete/5
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
