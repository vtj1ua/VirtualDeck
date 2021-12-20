using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckWeb.Controllers
{
    public class UserCardController : BasicController
    {
        // GET: UserCard
        public ActionResult Index(int idUsuario, int idCarta)
        {
            
            //(Session["User"] as VirtualUserEN).Tokens = ;
            UserCardCP userCardCP = new UserCardCP();
            userCardCP.DestroyCard(idCarta);

           
            return RedirectToAction(actionName: "Details", controllerName: "VirtualUser", new { id = idUsuario });
        }

        // GET: UserCard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCard/Create
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

        // GET: UserCard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserCard/Edit/5
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

        // GET: UserCard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserCard/Delete/5
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
