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
            VirtualUserEN virtualUserEN = Session["User"] as VirtualUserEN;
            try
            {
                // TODO: Add insert logic here
                TokenPackCP tokenPackCP = new TokenPackCP();
                

                tokenPackCP.PurchaseTokenPack(model.Id, virtualUserEN.Id);

                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Compra realizada", 
                    "Tu compra de '" + model.Name + "' se ha realizado correctamente");
                return RedirectToAction("Details", "VirtualUser", new { id = virtualUserEN.Id });
            }
            catch
            {
                TempData["OperationResult"] = new OperationResultViewModel(ModalMessageType.Success, "Error",
                    "Se ha producido un error al intentar efectuar la compra.");
                return RedirectToAction("Details", "VirtualUser", new { id = virtualUserEN.Id });
            }
        }
    }
}
