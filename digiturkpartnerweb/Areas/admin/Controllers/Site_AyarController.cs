using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digiturkveri;
using WebMatrix.WebData;

namespace digiturkpartnerweb.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Site_AyarController : Controller
    {
        private digiturkEntities db = new digiturkEntities();

        // GET: admin/Site_Ayar
        public ActionResult Index()
        {
            var site_Ayar = db.Site_Ayars.Include(s => s.kullanici);
            return View(site_Ayar.ToList());
        }

        // GET: admin/Site_Ayar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_Ayar site_Ayar = db.Site_Ayars.Find(id);
            if (site_Ayar == null)
            {
                return HttpNotFound();
            }
            return View(site_Ayar);
        }

        // GET: admin/Site_Ayar/Create
        public ActionResult Create()
        {
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi");
            return View();
        }

        // POST: admin/Site_Ayar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ayarid,kid,sitetel,ayartarih,siteadi")] Site_Ayar site_Ayar)
        {
            if (ModelState.IsValid)
            {
                db.Site_Ayars.Add(site_Ayar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", site_Ayar.kid);
            return View(site_Ayar);
        }

        // GET: admin/Site_Ayar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_Ayar site_Ayar = db.Site_Ayars.Find(id);
            if (site_Ayar == null)
            {
                return HttpNotFound();
            }
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", site_Ayar.kid);
            return View(site_Ayar);
        }

        // POST: admin/Site_Ayar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ayarid,kid,sitetel,ayartarih,siteadi")] Site_Ayar site_Ayar)
        {
            if (ModelState.IsValid)
            {
                site_Ayar.kid = WebSecurity.GetUserId(User.Identity.Name);
                site_Ayar.ayartarih = DateTime.Now;
                db.Entry(site_Ayar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", site_Ayar.kid);
            return View(site_Ayar);
        }

        // GET: admin/Site_Ayar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_Ayar site_Ayar = db.Site_Ayars.Find(id);
            if (site_Ayar == null)
            {
                return HttpNotFound();
            }
            return View(site_Ayar);
        }

        // POST: admin/Site_Ayar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site_Ayar site_Ayar = db.Site_Ayars.Find(id);
            db.Site_Ayars.Remove(site_Ayar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
