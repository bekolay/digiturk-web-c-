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

namespace digiturkpartnerweb.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class kategorisController : Controller
    {
        private digiturkEntities db = new digiturkEntities();

        // GET: admin/kategoris
        
        public ActionResult Index()
        {
            var kategori = db.kategoris.Include(k => k.kullanici);
            return View(kategori.ToList());
        }

        // GET: admin/kategoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: admin/kategoris/Create
        public ActionResult Create()
        {
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi");
            return View();
        }

        // POST: admin/kategoris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kateid,kid,kateadi,katetarih,kateurl,kateaktif")] kategori kategori)
        {
            var kategorilers = db.kategoris.Where(a => a.kateadi == kategori.kateadi).FirstOrDefault();

            if (kategorilers == null)
            {
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", kategori.kid);
                kategori.kid = WebSecurity.GetUserId(User.Identity.Name);
                kategori.kateurl = kategori.kateadi.Seo();
                kategori.katetarih = DateTime.Now;
                kategori.kateaktif = true;
                db.kategoris.Add(kategori);
                db.SaveChanges();
                ModelState.AddModelError("", "Kayıt Başarılı");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Kategori bulunmakta");
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", kategori.kid);
                return View(kategori);
            }

            
        }

        // GET: admin/kategoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", kategori.kid);
            return View(kategori);
        }

        // POST: admin/kategoris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kateid,kid,kateadi,katetarih,kateurl,kateaktif")] kategori kategori)
        {
            if (ModelState.IsValid)
            {
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", kategori.kid);
                kategori.kid = WebSecurity.GetUserId(User.Identity.Name);
                kategori.kateurl = kategori.kateadi.Seo();
                kategori.katetarih = kategori.katetarih;
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", kategori.kid);
            return View(kategori);
        }

        // GET: admin/kategoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategori kategori = db.kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: admin/kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategori kategori = db.kategoris.Find(id);
            db.kategoris.Remove(kategori);
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
