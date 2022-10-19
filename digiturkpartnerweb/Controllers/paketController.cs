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
    public class paketController : Controller
    {
        private digiturkEntities db = new digiturkEntities();
        private digiturkkampanyaEntities1 dbb = new digiturkkampanyaEntities1();
        // GET: paket
        public ActionResult p(string id)
        {
            //if (id == null)
            //{
            //    return RedirectToAction("index", "home");
            //}

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var paketlers = db.pakets
            .Include(p => p.kategori)
            .Include(p => p.paketResim)
            .Include(p => p.kullanici)
            .FirstOrDefault(p => p.paktif && p.purl == id);


            //ViewBag.Yorumlar = bloglar.BlogYorums.Where(p => p.BlogAkitf == true).ToArray();
            //ViewBag.blogid = bloglar.BlogİD;
            //ViewBag.KullaniciId = WebSecurity.GetUserId(User.Identity.Name);
            //ViewBag.pid = paketlers.pid;
            db.SaveChanges();
            return View(paketlers);
        }

        public ActionResult pp(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //if (id == null)
            //{
            //    return RedirectToAction("index", "home");
            //}

            var paketlers = dbb.paketkampanyas
            .Include(p => p.kategorikampanya)
            .FirstOrDefault(p => p.paktif && p.purl == id);

            if (paketlers.purl != id)
            {
                return RedirectToAction("hata");
            }


            //ViewBag.Yorumlar = bloglar.BlogYorums.Where(p => p.BlogAkitf == true).ToArray();
            //ViewBag.blogid = bloglar.BlogİD;
            //ViewBag.KullaniciId = WebSecurity.GetUserId(User.Identity.Name);
            //ViewBag.pid = paketlers.pid;
            dbb.SaveChanges();
            return View(paketlers);
        }
    }
}