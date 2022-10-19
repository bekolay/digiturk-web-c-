using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using digiturkveri;
using digiturkpartnerweb.Controllers;
using System.Web.Security;

namespace digiturkpartnerweb.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class basvurusController : Controller
    {
        private digiturkEntities db = new digiturkEntities();

        // GET: admin/basvurus

        public ActionResult Index()
        {
            var basvuru = db.basvurus.Include(b => b.paket);
            return View(basvuru.ToList());
        }

        // GET: admin/basvurus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            basvuru basvuru = db.basvurus.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // GET: admin/basvurus/Create
        public ActionResult Create()
        {
            ViewBag.pid = new SelectList(db.pakets, "pid", "padi");
            return View();
        }

        // POST: admin/basvurus/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "basvuruid,basvuruadisoyadi,basvurutel,basvurukabul,basipadres,pid")] basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.basvurus.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pid = new SelectList(db.pakets, "pid", "padi", basvuru.pid);
            return View(basvuru);
        }

        // GET: admin/basvurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            basvuru basvuru = db.basvurus.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            ViewBag.pid = new SelectList(db.pakets, "pid", "padi", basvuru.pid);
            return View(basvuru);
        }

        // POST: admin/basvurus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "basvuruid,basvuruadisoyadi,basvurutel,basvurukabul,basipadres,pid")] basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basvuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pid = new SelectList(db.pakets, "pid", "padi", basvuru.pid);
            return View(basvuru);
        }

        // GET: admin/basvurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            basvuru basvuru = db.basvurus.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // POST: admin/basvurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            basvuru basvuru = db.basvurus.Find(id);
            db.basvurus.Remove(basvuru);
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
