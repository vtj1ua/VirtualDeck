using System;
using System.Collections.Generic;
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
    public class TokenPackController : BasicController
    {
        [Authorize]
        public ActionResult Buy(int id)
        {
            SessionInitialize();

            TokenPackCAD tokenPackCAD = new TokenPackCAD(session);
            TokenPackCEN tokenPackCEN = new TokenPackCEN(tokenPackCAD);

            TokenPackEN tokenPackEN = tokenPackCEN.ReadOID(id);
            TokenPackAssembler assembler = new TokenPackAssembler();
            TokenPackViewModel model = assembler.ConvertENToModelUI(tokenPackEN);

            SessionClose();

            return View(model);
        }

        // POST: TokenPack/Create
        [HttpPost]
        [Authorize]
        public ActionResult Buy(TokenPackViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                TokenPackCP tokenPackCP = new TokenPackCP();
                VirtualUserEN virtualUserEN = Session["User"] as VirtualUserEN;

                tokenPackCP.PurchaseTokenPack(model.Id, virtualUserEN.Id);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
