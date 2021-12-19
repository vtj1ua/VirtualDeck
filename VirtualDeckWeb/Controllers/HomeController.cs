using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
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
            CardCP cardCP = new CardCP();

            IList<CardEN> newCards = cardcen.ReadAll(0,10);
            IEnumerable<CardViewModel> newCardsModel = new CardAssembler().ConvertListENToModel(newCards).ToList();

            VirtualUserEN virtualUser = (Session["User"] as VirtualUserEN); 
            if(virtualUser != null)
            {
                IList<CardEN> recommendedCards = cardCP.GetUserRecommendedCards(virtualUser.Id);
                IEnumerable<CardViewModel> recommendedCardsModel = new CardAssembler().ConvertListENToModel(recommendedCards).ToList();
                ViewData["RecommendedCards"] = recommendedCardsModel;
            }
            
            ViewData["NewCards"] = newCardsModel;
            

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