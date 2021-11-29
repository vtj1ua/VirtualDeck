using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;
using VirtualDeckWeb.Assemblers;

namespace VirtualDeckWeb.Controllers
{
    public class TokenController : BasicController
    {
        // GET: Token
        public ActionResult Index()
        {
            // se muestran los datos de los controller
            SessionInitialize();
            TokenPackCAD tokenCAD = new TokenPackCAD(session);
            TokenPackCEN tokenCEN = new TokenPackCEN(tokenCAD);

            /* Paginación */
            IList<TokenPackEN> tokenEN = tokenCEN.ReadAll(0, -1);
            IEnumerable<TokenPackViewModel> listView = new TokenPackAssembler().ConvertListENToModel(tokenEN).ToList();
            SessionClose();



            return View(listView);
        }

        // GET: Token/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Token/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Token/Create
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

        // GET: Token/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Token/Edit/5
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

        // GET: Token/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Token/Delete/5
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
