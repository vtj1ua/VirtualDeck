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
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using System.IO;
using System.Diagnostics;

namespace VirtualDeckWeb.Controllers
{
    public class VirtualUserController : BasicController
    {
        // GET: VirtualUser
        public ActionResult Index(String search, int page = 0)
        {
            SessionInitialize();

            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            IList<VirtualUserEN> virtualUserEN = null;

            if (search != null && search != "")
            {
                virtualUserEN = virtualUserCEN.UsersByName("%" + search + "%");
                this.ViewBag.Search = search;
            }
            else
            {
                virtualUserEN = virtualUserCEN.ReadAll(0, -1).ToList();
                this.ViewBag.Search = search;
            }

            int PageSize = 5;

            var count = virtualUserEN.Count();

            virtualUserEN = virtualUserEN.Skip(page * PageSize).Take(PageSize).ToList();

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

            IEnumerable<VirtualUserViewModel> model = new VirtualUserAssembler().ConvertListENToModel(virtualUserEN);
            SessionClose();
            return View(model);
        }

        // GET: VirtualUser/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(id);
            VirtualUserViewModel model = new VirtualUserAssembler().ConvertENToModelUI(virtualUserEN);

            /*LISTA DE LAS CARTAS DEL USUARIO*/
            UserCardCAD userCardCAD = new UserCardCAD(session);
            UserCardCEN userCardCEN = new UserCardCEN(userCardCAD);
            IList<UserCardEN> userCardENList = userCardCEN.UserCardsByUser(id);
            
            IEnumerable<UserCardViewModel> userCardViewModelList = new UserCardAssembler().ConvertListENToModel(userCardENList);

            /*LISTA DE LOS SOBRES DEL USUARIO*/
            UserPackCAD userPackCAD = new UserPackCAD(session);
            UserPackCEN userPackCEN = new UserPackCEN(userPackCAD);
            IList<UserPackEN> userPackENList = userPackCEN.UserPacksByUser(id);
            IEnumerable<UserPackViewModel> userPackViewModelList = new UserPackAssembler().ConvertListENToModel(userPackENList);


            ViewData["userPackList"] = userPackViewModelList;
            ViewData["userCardList"] = userCardViewModelList;
            ViewData["idUser"] = model.Id;
            SessionClose();
            return View(model);
        }

        public ActionResult Edit()
        {
            SessionInitialize();
            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            VirtualUserEN en = Session["user"] as VirtualUserEN;
            if(en != null)
            {
                VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(en.Id);
                VirtualUserViewModel model = new VirtualUserAssembler().ConvertENToModelUI(virtualUserEN);
                SessionClose();
                return View(model);
            }
            SessionClose();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(VirtualUserViewModel usu, HttpPostedFileBase file)
        {
            Debug.WriteLine(usu.UserName);
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                Debug.WriteLine("file no null");
                string[] fileEntries = Directory.GetFiles(Server.MapPath("~/Resources"));
                VirtualUserEN v = Session["user"] as VirtualUserEN;
                foreach (string name in fileEntries)
                {
                    string f = Path.GetFileName(name);
                    if (f.Contains("_") && f.Split('_')[0]==v.Id.ToString()){
                        System.IO.File.Delete(name);
                    }
                }
                    
                fileName = v.Id + "_" + Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/Resources"), v.Id+"_"+Path.GetFileName(file.FileName));
                file.SaveAs(path);
            }
            Debug.WriteLine(fileName);

            //RECORDAR->RENDERACTION PARA PARTIAL VIEW

            try
            {
                Debug.WriteLine(usu.CombatStatus);
                VirtualUserEN vicen = Session["user"] as VirtualUserEN;
                VirtualUserCEN cen = new VirtualUserCEN();
                if (fileName == "")
                {
                    Debug.WriteLine("filename :"+fileName);
                    fileName = vicen.Img;
                }

                if (usu.DeletedImg == "1")
                {
                    fileName = "usuario.png";
                }

                Debug.WriteLine("------------");
                Debug.WriteLine(vicen.Id);
                Debug.WriteLine(vicen.Pass);
                Debug.WriteLine(usu.UserName);
                Debug.WriteLine(vicen.Email);
                Debug.WriteLine(usu.Description);
                Debug.WriteLine(vicen.Tokens);
                Debug.WriteLine(fileName);
                Debug.WriteLine(vicen.CombatStatus);
                Debug.WriteLine("------------");

                if (usu.Description == null)
                {
                    usu.Description = "";
                }
                if (usu.UserName == null)
                {
                    usu.UserName = vicen.UserName;
                }
                Debug.WriteLine(vicen.Pass);



                cen.Modify(vicen.Id, vicen.Pass, usu.UserName, vicen.Email, usu.Description, vicen.Tokens, fileName, vicen.CombatStatus);
                

                IList<VirtualUserEN> vicen1 = cen.UsersByEmail(vicen.Email);
                if (vicen1.Count > 0)
                {
                    Session["user"] = vicen1[0];
                    VirtualUserEN vicen2 = Session["user"] as VirtualUserEN;
                    Debug.WriteLine(vicen2.Id);
                    Debug.WriteLine(vicen2.Pass);
                    Debug.WriteLine(vicen2.UserName);
                    Debug.WriteLine(vicen2.Email);
                    Debug.WriteLine(vicen2.Description);
                    Debug.WriteLine(vicen2.Tokens);
                    Debug.WriteLine(vicen2.Img);
                    Debug.WriteLine(vicen2.CombatStatus);
                }

                return RedirectToAction("Details", new { Id=vicen.Id});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index1(int page = 0)
        {
            const int PageSize = 3; // you can always do something more elegant to set this

            VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
            VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
            IList<VirtualUserEN> virtualUserEN = null;

           
            virtualUserEN = virtualUserCEN.ReadAll(0, -1).ToList();

            var count = virtualUserEN.Count();

            var data = virtualUserEN.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Total = 3;

            if (count % PageSize != 0)
            {
                this.ViewBag.Total = (count / PageSize)+1;
            }
            

            this.ViewBag.Page = page;

            return this.View(data);
        }
    }
}