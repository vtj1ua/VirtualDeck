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
        public ActionResult Index(String search, int page = 0)
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
            {
                tradeOffEN = tradeOffCEN.TradesByCardName("%" + search + "%");
                this.ViewBag.Search = search;
            }
            else
            {
                this.ViewBag.Search = "";
                tradeOffEN = tradeOffCEN.TradesPending();
            }
                

            int PageSize = 5;

            var count = tradeOffEN.Count();

            tradeOffEN = tradeOffEN.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Total = 0;

            if (count % PageSize != 0)
            {
                this.ViewBag.Total = (count / PageSize) + 1;
            }
            else
            {
                this.ViewBag.Total = (count / PageSize);
            }

            this.ViewBag.Page = page;


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




        [HttpPost]
        public ActionResult CardSelectedToTrade(FormCollection collection)
        {
     
            int idCarta = Int32.Parse(collection.Get("idCarta"));
            int idTrade = Int32.Parse(collection.Get("idTrade"));
            VirtualUserEN vicen = Session["user"] as VirtualUserEN;
            TradeOffCP trade = new TradeOffCP();

            trade.Trade(idTrade, idCarta);

            TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Intercambio realizado",
                 "El intercambio se ha realizado correctamente");

            return RedirectToAction("Index");

        }
        public ActionResult SelectToTrade(int idTrade, int idDesired, int page = 0)
        {
            this.ViewBag.IdTrade = idTrade;
            this.ViewBag.IdDesired = idDesired;

            UserCardCAD UserCardCAD = new UserCardCAD(session);
            UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
            IList<UserCardEN> UserCardEN = null;

            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if (en != null)
            {
                UserCardEN = UserCardCEN.UserCardsByBaseCard(en.Id,idDesired);
            }

            int PageSize = 8;

            var count = UserCardEN.Count();

            UserCardEN = UserCardEN.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Total = 0;

            if (count % PageSize != 0)
            {
                this.ViewBag.Total = (count / PageSize) + 1;
            }
            else
            {
                this.ViewBag.Total = (count / PageSize);
            }

            this.ViewBag.Page = page;


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
            ViewData["idDesired"] = idDesired;
            return View();
        }


        /*#############PUBLICAR UN ANUNCIO###########################*/
        public ActionResult SelectUserCardToPublish(String search, int page = 0)
        {
            UserCardCAD UserCardCAD = new UserCardCAD(session);
            UserCardCEN UserCardCEN = new UserCardCEN(UserCardCAD);
            IList<UserCardEN> UserCardEN = null;

            VirtualUserEN en = Session["user"] as VirtualUserEN;

            if (search != null && search != "")
            {
                UserCardEN = UserCardCEN.UserCardsByName(en.Id,"%" + search + "%");
                this.ViewBag.Search = search;
            }
            else
            {
                this.ViewBag.Search = "";
                UserCardEN = UserCardCEN.UserCardsNotInTradeByUser(en.Id);
            }

            int PageSize = 8;

            var count = UserCardEN.Count();

            UserCardEN = UserCardEN.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Total = 0;

            if (count % PageSize != 0)
            {
                this.ViewBag.Total = (count / PageSize) + 1;
            }
            else
            {
                this.ViewBag.Total = (count / PageSize);
            }

            this.ViewBag.Page = page;


            IEnumerable<UserCardViewModel> model = new UserCardAssembler().ConvertListENToModel(UserCardEN);


            ViewData["usercards"] = model;
            ViewData["idUser"] = en.Id;
            return View();
        }

        
        public ActionResult SelectCardToPublish(int idOffered, String search, int page = 0)
        {
           
            CardCAD CardCAD = new CardCAD();
            CardCEN CardCEN = new CardCEN();
            IList<CardEN> CardEN = null;


            if (search != null && search != "")
            {
                CardEN = CardCEN.CardsByNameOrDescription( "%" + search + "%");
                this.ViewBag.Search = search;
            }
            else
            {
                this.ViewBag.Search = "";
                CardEN = CardCEN.ReadAll(0, -1);
            }

            int PageSize = 8;

            var count = CardEN.Count();

            CardEN = CardEN.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Total = 0;

            if (count % PageSize != 0)
            {
                this.ViewBag.Total = (count / PageSize) + 1;
            }
            else
            {
                this.ViewBag.Total = (count / PageSize);
            }

            this.ViewBag.Page = page;



            IEnumerable<CardViewModel> model = new CardAssembler().ConvertListENToModel(CardEN);


            ViewData["cards"] = model;
            ViewData["idOffered"] = idOffered;
           

            return View();

        }

        [HttpPost]
        public ActionResult Publish(FormCollection collection)
        {
            int idOffered = Int32.Parse(collection.Get("idOffered"));
            int idDesired = Int32.Parse(collection.Get("idDesired"));
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

            return View();
        }

        [HttpPost]
        public ActionResult FinishAndPublish(FormCollection collection)
        {
            SessionInitialize();
            int idOffered = Int32.Parse(collection.Get("idOffered"));
            int idDesired = Int32.Parse(collection.Get("idDesired"));
            VirtualUserEN vicen = Session["user"] as VirtualUserEN;

            UserCardCAD userCardCAD = new UserCardCAD(session);
            UserCardCEN userCardCEN = new UserCardCEN(userCardCAD);
            UserCardEN userCardOffered = userCardCEN.ReadOID(idOffered);

            IList<UserCardEN> userCards = userCardCEN.UserCardsByUser(vicen.Id);

            //compruebo que sea una carta del usuario
            if (userCards.IndexOf(userCardOffered) !=-1)
            {
                TradeOffCEN trade = new TradeOffCEN();
                trade.Publish(vicen.Id, idDesired, idOffered);
                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Anuncio publicado",
                  "Tu intercambio se ha publicado correctamente");
            }
            else
            {
                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Error, "No se pudo publicar",
                  "Ha ocurrido un error al publicar el anuncio");
            }
            SessionClose();
            return RedirectToAction("Index");
        }

        //########################################################################

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            int idTrade = Int32.Parse(collection.Get("idTrade"));
           
            TradeOffCAD tradeOffCAD = new TradeOffCAD();
            TradeOffCEN tradeOffCEN = new TradeOffCEN(tradeOffCAD);
            tradeOffCEN.Destroy(idTrade);

            TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Anuncio borrado",
                 "Tu anuncio se ha borrado correctamente");

            return RedirectToAction("Index");
        }
    }
}
