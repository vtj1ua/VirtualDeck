using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualDeckWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página sobre mi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto";

            return View();
        }

        public ActionResult Tienda()
        {
            ViewBag.Message = "Página de la tienda";

            return View();
        }

        public ActionResult Usuarios()
        {
            ViewBag.Message = "Página de usuarios";

            return View();
        }
    }
}