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
            ViewBag.Message = "Virtual Deck";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacta con el servicio técnico";

            return View();
        }

        public ActionResult Tienda()
        {
            ViewBag.Message = "En esta página podrás acceder a la tienda, donde podrás comprar carta, sobres y tokens";

            return View();
        }

        public ActionResult Usuarios()
        {
            ViewBag.Message = "En esta págia podrás buscar otros usuarios y ver su perfil dentro del juego";

            return View();
        }
    }
}