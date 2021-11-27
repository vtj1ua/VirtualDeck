using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckWeb.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            CardCEN cardCEN = new CardCEN();
            List<CardEN> cardEN = cardCEN.ReadAll(1, 50).ToList();

            return View(cardEN);
        }

        // GET: Card/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Card/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Card/Create
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

        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Card/Edit/5
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

        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Card/Delete/5
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
