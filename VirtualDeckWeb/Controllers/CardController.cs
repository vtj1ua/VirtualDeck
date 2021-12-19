using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;
using VirtualDeckWeb.Models;
//email
using System.Net;
using System.Net.Mail;


using VirtualDeckWeb.Assemblers;

namespace VirtualDeckWeb.Controllers
{
    public class CardController : BasicController
    {
        // GET: Card
        public ActionResult Index()
        {
            SessionInitialize();
            CardCAD cardCad = new CardCAD(session);
            CardCEN cardCEN = new CardCEN(cardCad);

            /* Paginación */
            IList<CardEN> cardEN = cardCEN.ReadAll(0, -1);
            IEnumerable<CardViewModel> listView = new CardAssembler().ConvertListENToModel(cardEN).ToList();
            SessionClose();

            return View(listView);
        }

        // GET: Card/Details/5
        public ActionResult Details(int id)
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

        // GET: Card/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Card/Buy
        [HttpPost]
        public ActionResult Buy(FormCollection collection)
        {
            try
            {
                //SessionInitialize();
                int cardId = Int32.Parse(collection.Get("cardId"));
                CardCEN cardCEN = new CardCEN();
                CardEN CardEN = cardCEN.ReadOID(cardId);
                // TODO: Add insert logic here
                int amount = Int32.Parse(collection.Get("amount"));

                UserCardCEN userCardCEN = new UserCardCEN();
                VirtualUserEN user = Session["User"] as VirtualUserEN;

                CardCP cardCP = new CardCP();
                cardCP.PurchaseUserCard(cardId, user.Id, amount);

                // correo -----------------------------
                
                string web = "https://virtualdeck.000webhostapp.com/img/logoAzul.png";
                
                string body = "<div style=\"color: #fff; background: #000; width: 500px; height: 300px; text-align: center; padding-top: 1em; border-radius: .5em\">" +
                        "<img src = \"" + web +"\" alt = \"VirtualDeck\" style = \"width: 50px;\">" +
   
                            "<h1 style = \"color: #fff; margin-top: 0.1em;\">Compra realizada </h1>" +
        
                            "<hr style = \"color: #fff; background: #fff; width: 300px;\">" +
         
                            "<p style = \"color: #fff;\">Se ha realizado la compra satisfactoriamente.</p>" +
              
                            "<p style = \"color: #fff;\">¡Enhorabuena!</p>" +
                  
                            "<p style = \"color: #fff;\">Ya perteneces a nuestra comunidad.</p>" +
                        "</div>";

                MailMessage msj = new MailMessage();
                SmtpClient cli = new SmtpClient();

                //String email = CreateUserWizard1.Email.ToString();

                msj.From = new MailAddress("VirtualDeckDSM@gmail.com");
                msj.To.Add(new MailAddress("jmu3@gcloud.ua.es"));
                msj.To.Add(new MailAddress("mjlv3@gcloud.ua.es"));

                msj.Subject = "VirtualDeck";
                //msj.Body = "Hola Compañero Stiven, felicidades por obtener nuestra mejor carta.";
                msj.Body = body;
                msj.IsBodyHtml = true;


                cli.Host = "smtp.gmail.com";
                cli.Port = 587;
                cli.Credentials = new NetworkCredential("VirtualDeckDSM@gmail.com", "virtualdeckcorreo123");
                cli.EnableSsl = true;
                cli.Send(msj);
                
                // correo -----------------------------
                return RedirectToAction(actionName: "Cards", controllerName: "Shop");
            }
            catch
            {
                //return View();
                return RedirectToAction(actionName: "Cards", controllerName: "Shop");
            }
           
        }

        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Card/Edit/5
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

        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Card/Delete/5
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
