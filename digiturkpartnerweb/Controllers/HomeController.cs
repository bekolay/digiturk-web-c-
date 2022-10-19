using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digiturkpartnerweb.Controllers;
using digiturkveri;
using WebMatrix.WebData;


namespace digiturkpartnerweb.Controllers
{
    public class HomeController : Controller
    {
        private digiturkkampanyaEntities1 db = new digiturkkampanyaEntities1();

        //public ActionResult Index(string il)
        //{
        //    il = "ankara";

        //    if (il == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return View(il);
        //    }

        [Route("/")]
        public ActionResult Index()
        {

            return View();
        }

        [Route("/{anasayfa}")]
        public ActionResult il(string id)
        {

            var paketlers = db.kategorikampanyas
            .Include(p => p.paketkampanyas)
            .FirstOrDefault(p=>p.kateurl == id);

            if (paketlers.kateurl != id)
            {
                return RedirectToAction("hata");
            }

            ViewBag.isim = paketlers.kateadi;

            return View(paketlers.paketkampanyas.Where(p => p.paktif == true));
        }

        //public ActionResult il(string id)
        //{
        //    string[] iller = { "ankara", "istanbul" };

        //    var iller1 = 

        //    return View(iller == id);
        //}


        //[Route("/")]
        //public ActionResult Index() => MainMethod();

        //[Route("/{city}")]
        //public ActionResult Index(string city) => MainMethod();

        //private ActionResult MainMethod()
        //{
        //    string data = "ANASAYFA ASLA DEĞİŞMEZ";
        //    ViewData["data"] = data;
        //    return View();
        //}

        //public ActionResult il(string il1)
        //{
        //    il1 = "Ankara";

        //    if (il1 == null)
        //    {
        //        return RedirectToAction("View");
        //    }
        //    else
        //    {
        //        return View(il1);
        //    }
        //}
    }
}