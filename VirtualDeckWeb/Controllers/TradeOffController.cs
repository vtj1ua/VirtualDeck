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
    public class TradeOffController : BasicController
    {
        // GET: TradeOff
        public ActionResult Index(String search)
        {
            SessionInitialize();

            TradeOffCAD tradeOffCAD = new TradeOffCAD(session);
            TradeOffCEN tradeOffCEN = new TradeOffCEN(tradeOffCAD);
            IList<TradeOffEN> tradeOffEN = null;

            if (search != null && search != "")
                tradeOffEN = tradeOffCEN.TradesByCardName("%" + search + "%");
            else
                tradeOffEN = tradeOffCEN.ReadAll(0, -1).ToList();

            IEnumerable<TradeOffViewModel> model = new TradeOffAssembler().ConvertListENToModel(tradeOffEN);
            SessionClose();
            return View(model);
        }

        // GET: TradeOff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TradeOff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeOff/Create
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

        // GET: TradeOff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TradeOff/Edit/5
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

        // GET: TradeOff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TradeOff/Delete/5
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
