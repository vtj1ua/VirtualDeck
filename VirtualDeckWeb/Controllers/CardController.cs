using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
using VirtualDeckWeb.Models;

using VirtualDeckWeb.Assemblers;

namespace VirtualDeckWeb.Controllers
{
    public class CardController : BasicController
    {
        // GET: Card
        public ActionResult Index()
        {
            SessionInitialize();
            CardCAD cardCad = new CardCAD(session);
            CardCEN cardCEN = new CardCEN(cardCad);

            /* Paginación */
            IList<CardEN> cardEN = cardCEN.ReadAll(0, -1);
            IEnumerable<CardViewModel> listView = new CardAssembler().ConvertListENToModel(cardEN).ToList();
            SessionClose();

            return View(listView);
        }

        // GET: Card/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            CardCAD cardCAD = new CardCAD(session);
            CardCEN cardCEN = new CardCEN(cardCAD);
            CardEN cardEN = cardCEN.ReadOID(id);

            List<AttackMoveEN> list = cardEN.AttackMoves.ToList();
            IEnumerable<AttackMoveViewModel> attackList = new AttackMoveAssembler().ConvertListENToModel(list).ToList();

            CardViewModel model = new CardAssembler().ConvertENToModelUI(cardEN);

            //ViewData["Card"] = model;
            ViewData["Attack"] = attackList;

            SessionClose();
            return View(model);
        }

        // GET: Card/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Card/Buy
        [HttpPost]
        public ActionResult Buy(FormCollection collection)
        {
            int cardId = 0;
            try
            {
                cardId = Int32.Parse(collection.Get("cardId"));
                int amount = Int32.Parse(collection.Get("amount"));

                UserCardCEN userCardCEN = new UserCardCEN();
                VirtualUserEN user = Session["User"] as VirtualUserEN;

                CardCP cardCP = new CardCP();
                cardCP.PurchaseUserCard(cardId, user.Id, amount);

                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Compra realizada",
                   "Tu compra se ha realizado correctamente");
                return RedirectToAction("Details", "VirtualUser", new { id = user.Id });
            }
            catch
            {
                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Error, "Error",
                   "No tienes suficiente dinero");
                return RedirectToAction("Details", new { id = cardId });
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
