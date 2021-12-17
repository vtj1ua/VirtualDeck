using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckWeb.Controllers
{
    public class UserPackController : BasicController
    {
        // GET: UserPack
        public ActionResult Index(int idPack)
        {
            VirtualUserEN user = Session["User"] as VirtualUserEN;
            UserPackCP userPackCP = new UserPackCP();
            userPackCP.OpenPack(idPack);

            return RedirectToAction(actionName: "Details", controllerName: "VirtualUser", new { id = user.Id });
        }


        // GET: UserPack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserPack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserPack/Create
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

        // GET: UserPack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserPack/Edit/5
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

        // GET: UserPack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserPack/Delete/5
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
