using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualDeckWeb.Controllers
{
    public class ShopController : BasicController
    {
        // GET: Tienda
        public ActionResult Index()
        {
            ViewBag.Message = "En esta página podrás acceder a la tienda, donde podrás comprar carta, sobres y tokens";
            return View();
        }

        public ActionResult CardIndex()
        {
            ViewBag.Message = "En esta página podrás acceder a la tienda, donde podrás comprar carta, sobres y tokens";
            return View();
        }
    }
}
