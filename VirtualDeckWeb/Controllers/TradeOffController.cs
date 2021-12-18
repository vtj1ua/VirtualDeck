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
        public ActionResult Publish()
        {

            UserCardCAD UserCardCAD = new UserCardCAD(session);
            UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
            IList<UserCardEN> UserCardEN = null;

            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if (en != null)
            {
                UserCardEN = UserCardCEN.UserCardsByUser(en.Id);
            }

            IEnumerable<UserCardViewModel> model = new UserCardAssembler().ConvertListENToModel(UserCardEN);

            CardCAD CardCAD = new CardCAD(session);
            CardCEN CardCEN = new CardCEN(CardCAD);
            IList<CardEN> CardEN = null;


            CardEN = CardCEN.ReadAll(0, -1).ToList();

            IEnumerable<CardViewModel> model1 = new CardAssembler().ConvertListENToModel(CardEN);
            ViewData["usercards"] = model;
            ViewData["cards"] = model1;

            return View();
        }

        // POST: TradeOff/Create
        [HttpPost]
        public ActionResult Publish(TradeOffViewModel tradeoff)
        {
            try
            {
               
                VirtualUserEN vicen = Session["user"] as VirtualUserEN;
                TradeOffCEN trade = new TradeOffCEN();

                trade.Publish(vicen.Id, tradeoff.DesiredCard.Id, tradeoff.OfferedUserCard.Id);

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
