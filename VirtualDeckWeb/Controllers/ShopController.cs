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
        public ActionResult Cards(String search)
        {
            SessionInitialize();
            CardCAD cardcad = new CardCAD(session);
            CardCEN cardcen = new CardCEN(cardcad);
            IList<CardEN> cards = null;
            if (search != null && search != "")
                cards = cardcen.CardsByNameOrDescription("%" + search + "%");
            else
                cards = cardcen.ReadAll(0, -1);

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

        [Authorize]
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
    }
}
