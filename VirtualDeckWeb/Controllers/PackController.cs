using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
using VirtualDeckWeb.Assemblers;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Controllers
{
    public class PackController : BasicController
    {
        // GET: Pack
        public ActionResult Index(String search)
        {
            SessionInitialize();

            PackCAD packcad = new PackCAD(session);
            PackCEN packcen = new PackCEN(packcad);
            IList<PackEN> packs = null;
            
            if(search != null && search != "")
                packs = packcen.PacksByNameOrDescription(search);
            else
                packs = packcen.ReadAll(0, -1);

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

            /*
            SessionInitialize();
            CardCAD cardCAD = new CardCAD(session);
            CardCEN cardCEN = new CardCEN(cardCAD);
            CardEN cardEN = cardCEN.ReadOID(id);

            //List<AttackMoveEN> list = cardEN.AttackMoves.ToList();
            //IEnumerable<AttackMoveViewModel> attackList = new AttackMoveAssembler().ConvertListENToModel(list).ToList();

            PackViewModel model = new PackAssembler().ConvertENToModelUI(packEN);

            //ViewData["Card"] = model;
            //ViewData["Attack"] = attackList;

            SessionClose();
            return View(model);
            */
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


        // POST: Pack/Buy
        [HttpPost]
        public ActionResult Buy(FormCollection collection)
        {
            try
            {
                //SessionInitialize();
                int packId = Int32.Parse(collection.Get("packId"));
                // TODO: Add insert logic here
                int amount = Int32.Parse(collection.Get("amount"));

                UserPackCEN userPackCEN = new UserPackCEN();
                VirtualUserEN user = Session["User"] as VirtualUserEN;

                PackCP packCP = new PackCP();
                packCP.PurchaseUserPack(packId, user.Id, amount);


                return RedirectToAction(actionName: "Packs", controllerName: "Shop");
            }
            catch
            {
                //return View();
                return RedirectToAction(actionName: "Packs", controllerName: "Shop");
            }

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


        /*public ActionResult Search(FormCollection collection)
        {
            SessionInitialize();
            Console.WriteLine("Entro");
            PackCAD packcad = new PackCAD(session);
            PackCEN packcen = new PackCEN(packcad);
            IList<PackEN> packs = packcen.PacksByNameOrDescription(collection["packNameOrDescription"]);
            IEnumerable<PackViewModel> listaPacks = new PackAssembler().ConvertListENToModel(packs).ToList();
            SessionClose();
            return View(listaPacks);
        }*/
    }
}
