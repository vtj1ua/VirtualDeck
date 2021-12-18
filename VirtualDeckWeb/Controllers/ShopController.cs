using System;
using System.Collections.Generic;
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
    public class ShopController : BasicController
    {
        // GET: Shop
        public ActionResult Cards(String search, int page = 0)
        {
            SessionInitialize();
            CardCAD cardcad = new CardCAD(session);
            CardCEN cardcen = new CardCEN(cardcad);
            IList<CardEN> cards = null;
            if (search != null && search != "")
            {
                cards = cardcen.CardsByNameOrDescription("%" + search + "%");
                this.ViewBag.Search = search;
            }
            else
            {
                cards = cardcen.ReadAll(0, -1);
                this.ViewBag.Search = "";
            }

            int PageSize = 8;

            var count = cards.Count();

            cards = cards.Skip(page * PageSize).Take(PageSize).ToList();

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

            IEnumerable<CardViewModel> listaCards = new CardAssembler().ConvertListENToModel(cards).ToList();
            SessionClose();
            return View(listaCards);
        }

        public ActionResult Packs(String search)
        {
            SessionInitialize();

            PackCAD packcad = new PackCAD(session);
            PackCEN packcen = new PackCEN(packcad);
            IList<PackEN> packs = null;

            if (search != null && search != "")
                packs = packcen.PacksByNameOrDescription("%"+search+"%");
            else
                packs = packcen.ReadAll(0, -1);

            IEnumerable<PackViewModel> listaPacks = new PackAssembler().ConvertListENToModel(packs).ToList();

            SessionClose();

            return View(listaPacks);
        }

        public ActionResult TokenPacks()
        {
            SessionInitialize();
            TokenPackCAD tokencad = new TokenPackCAD(session);
            TokenPackCEN tokencen = new TokenPackCEN(tokencad);
            IList<TokenPackEN> tokens = tokencen.ReadAll(0, -1);
            IEnumerable<TokenPackViewModel> listaTokens = new TokenPackAssembler().ConvertListENToModel(tokens).ToList();
            SessionClose();
            return View(listaTokens);
        }

        // GET: Shop/Details/5
        public ActionResult CardDetails(int id)
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
        
        public ActionResult PackDetails(int id)
        {
            SessionInitialize();
            PackCAD PackCAD = new PackCAD(session);
            PackCEN PackCEN = new PackCEN(PackCAD);
            PackEN PackEN = PackCEN.ReadOID(id);
            PackViewModel model = new PackAssembler().ConvertENToModelUI(PackEN);
            SessionClose();
            return View(model);
        }

        public ActionResult TokenPackDetails(int id)
        {
            SessionInitialize();
            TokenPackCAD TokenPackCAD = new TokenPackCAD(session);
            TokenPackCEN TokenPackCEN = new TokenPackCEN(TokenPackCAD);
            TokenPackEN TokenPackEN = TokenPackCEN.ReadOID(id);
            TokenPackViewModel model = new TokenPackAssembler().ConvertENToModelUI(TokenPackEN);
            SessionClose();
            return View(model);
        }


        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
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

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
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

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
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
