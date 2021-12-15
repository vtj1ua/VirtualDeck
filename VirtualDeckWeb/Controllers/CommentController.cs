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
    public class CommentController : BasicController
    {
        public ActionResult ListPartial(int productID)
        {
            SessionInitialize();

            CommentCAD commentCAD = new CommentCAD(session);
            CommentCEN commentCEN = new CommentCEN(commentCAD);

            IList<CommentEN> comments = commentCEN.CommentsByProduct(productID);
            IEnumerable<CommentViewModel> commentModels = new CommentAssembler().ConvertListENToModel(comments);

            CommentViewModel publishComment = new CommentViewModel();
            publishComment.ProductId = productID;

            SessionClose();

            return PartialView(new Tuple<IEnumerable<CommentViewModel>, CommentViewModel>(commentModels, publishComment));
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentViewModel comment) //[Bind(Prefix = "Item2")] 
        {
            try
            {
                CommentCEN commentCEN = new CommentCEN();
                VirtualUserEN user = Session["User"] as VirtualUserEN;
                
                commentCEN.Publish(comment.Text, comment.ProductId, user.Id);
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
