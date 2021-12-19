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
using VirtualDeckGenNHibernate.CP.VirtualDeck;

namespace VirtualDeckWeb.Controllers
{
    public class TradeOffController : BasicController
    {

        // GET: TradeOff
        public ActionResult Index(String search)
        {

            VirtualUserEN virtualUser = Session["User"] as VirtualUserEN;
            SessionInitialize();

            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(virtualUser.Id);
            VirtualUserViewModel model = new VirtualUserAssembler().ConvertENToModelUI(virtualUserEN);

            TradeOffCAD tradeOffCAD = new TradeOffCAD(session);
            TradeOffCEN tradeOffCEN = new TradeOffCEN(tradeOffCAD);
            IList<TradeOffEN> tradeOffEN = null;

            if (search != null && search != "")
                tradeOffEN = tradeOffCEN.TradesByCardName("%" + search + "%");
            else
                tradeOffEN = tradeOffCEN.ReadAll(0, -1).ToList();
            /*HAY QUE PONER EL FILTRO ESE DE LOS TRADES ACTIVOS*/


            IEnumerable<TradeOffViewModel> tradeOffs = new TradeOffAssembler().ConvertListENToModel(tradeOffEN);


            /*LISTA DE LAS CARTAS DEL USUARIO*/
            UserCardCAD userCardCAD = new UserCardCAD(session);
            UserCardCEN userCardCEN = new UserCardCEN(userCardCAD);
            IList<UserCardEN> userCardENList = userCardCEN.UserCardsByUser(virtualUser.Id);


            IEnumerable<UserCardViewModel> userCardViewModelList = new UserCardAssembler().ConvertListENToModel(userCardENList);

            ViewData["userCardList"] = userCardViewModelList;
            ViewData["tradeOffsList"] = tradeOffs;
            ViewData["idUser"] = model.Id;

            SessionClose();
            return View();
        }


        public ActionResult Publish(int idOffered, int idDesired)
        {
            if(idOffered != -1 && idDesired != -1)
            {
                SessionInitialize();

                UserCardCAD UserCardCAD = new UserCardCAD(session);
                UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
                UserCardEN userCardSelected = UserCardCEN.ReadOID(idOffered);
                UserCardViewModel model1 = new UserCardAssembler().ConvertENToModelUI(userCardSelected);

                CardCAD CardCAD = new CardCAD(session);
                CardCEN CardCEN = new CardCEN(CardCAD);
                CardEN cardSelected = CardCEN.ReadOID(idDesired);
                CardViewModel model2 = new CardAssembler().ConvertENToModelUI(cardSelected);

                ViewData["userCardselected"] = model1;
                ViewData["cardselected"] = model2;
                SessionClose();

            }
            return View();
        }

        // POST: TradeOff/Create
      
       
        public ActionResult CardSelectedToTrade(int idCarta, int idTrade)
        {
            
            VirtualUserEN vicen = Session["user"] as VirtualUserEN;
            TradeOffCP trade = new TradeOffCP();

            trade.Trade(idTrade, idCarta);

            
            return RedirectToAction("Index");

        }
        public ActionResult SelectToTrade(int idTrade, int idDesired)
        {
            UserCardCAD UserCardCAD = new UserCardCAD(session);
            UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
            IList<UserCardEN> UserCardEN = null;

            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if (en != null)
            {
                UserCardEN = UserCardCEN.UserCardsByBaseCard(en.Id,idDesired);
            }

            IEnumerable<UserCardViewModel> model = new UserCardAssembler().ConvertListENToModel(UserCardEN);

            CardCAD CardCAD = new CardCAD(session);
            CardCEN CardCEN = new CardCEN(CardCAD);
            IList<CardEN> CardEN = null;


            CardEN = CardCEN.ReadAll(0, -1).ToList();

            IEnumerable<CardViewModel> model1 = new CardAssembler().ConvertListENToModel(CardEN);
            ViewData["usercards"] = model;
            ViewData["cards"] = model1;
            ViewData["idUser"] = en.Id;
            ViewData["idTrade"] = idTrade;
            return View();
        }
       
        public ActionResult SelectCardToPublish(int idOffered)
        {
            CardCAD CardCAD = new CardCAD();
            CardCEN CardCEN = new CardCEN();
            IList<CardEN> CardEN = CardCEN.ReadAll(0,-1);

          
            IEnumerable<CardViewModel> model = new CardAssembler().ConvertListENToModel(CardEN);


            ViewData["cards"] = model;
            ViewData["idOffered"] = idOffered;
           

            return View();

        }
        public ActionResult SelectUserCardToPublish()
        {
            UserCardCAD UserCardCAD = new UserCardCAD(session);
            UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
            IList<UserCardEN> UserCardEN = null;

            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if (en != null)
            {
                UserCardEN = UserCardCEN.UserCardsNotInTradeByUser(en.Id);
            }

            IEnumerable<UserCardViewModel> model = new UserCardAssembler().ConvertListENToModel(UserCardEN);

          
            ViewData["usercards"] = model;
            ViewData["idUser"] = en.Id;
            return View();
        }

        public ActionResult FinishAndPublish(int idOffered, int idDesired)
        {

            VirtualUserEN vicen = Session["user"] as VirtualUserEN;
            TradeOffCEN trade = new TradeOffCEN();

            trade.Publish(vicen.Id, idDesired, idOffered);

            return RedirectToAction("Index");


        }

        // GET: TradeOff/Delete/5
        public ActionResult Delete(int idTrade)
        {
            TradeOffCAD tradeOffCAD = new TradeOffCAD();
            TradeOffCEN tradeOffCEN = new TradeOffCEN(tradeOffCAD);
            tradeOffCEN.Destroy(idTrade);

            return RedirectToAction("Index");
        }
    }
}
