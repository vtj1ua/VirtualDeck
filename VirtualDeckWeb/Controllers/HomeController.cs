using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();
            CardCAD cardcad = new CardCAD(session);
            CardCEN cardcen = new CardCEN(cardcad);

            IList<CardEN> cards = cardcen.ReadAll(0,4);
            IEnumerable<CardViewModel> listaCards1 = new CardAssembler().ConvertListENToModel(cards).ToList();


            IList<CardEN> cards1 = cardcen.ReadAll(4, 4);
            IEnumerable<CardViewModel> listaCards2 = new CardAssembler().ConvertListENToModel(cards1).ToList();


            IList<CardEN> cards2 = cardcen.ReadAll(0, -1);
            IEnumerable<CardViewModel> listaCards3 = new CardAssembler().ConvertListENToModel(cards2).ToList();

            ViewData["List1"] = listaCards1;
            ViewData["List2"] = listaCards2;
            ViewData["List3"] = listaCards3;

            SessionClose();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}