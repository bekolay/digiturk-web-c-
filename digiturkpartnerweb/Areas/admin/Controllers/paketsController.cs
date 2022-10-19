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
    public class paketsController : Controller
    {
        private digiturkEntities db = new digiturkEntities();

        // GET: admin/pakets
        public ActionResult Index()
        {
            var paket = db.pakets.Include(b => b.kategori);
            ViewBag.Aktifblog = db.pakets.Include(b => b.kategori).Where(p => p.paktif == false).ToList();
            return View(paket.ToList());
        }

        // GET: admin/pakets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.pakets.Find(id);
            if (paket == null)
            {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                return HttpNotFound();
            }
            ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
            ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
            return View(paket);
        }

        // GET: admin/pakets/Create
        public ActionResult Create()
        {
            ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi");
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi");
            ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi");
            return View();
        }

        // POST: admin/pakets/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "pid,kid,kateid,padi,psenecekay1,psenecekay2,psenecekay3,psenecekay4,purl,pipadres,psenecekaciklama1,psenecekaciklama2,psenecekaciklama3,psenecekaciklama4," +
            "psenecekfiyat1,psenecekfiyat2,psenecekfiyat3,psenecekfiyat4" +
            "paciklama,pfiyat,ptaraftar,ptarih,pdizi,pfilm,pspor,pmenuekle,pinadi,pinadi2,pinadi3,pinadi4,pinhiz,pinhiz2,pinhiz3,pinhiz4," +
            "pinfiyat,pinfiyat2,pinfiyat3,pinfiyat4,pkampdetay,pinternet,paktif,pyazi,paysayi,panasayfaekle,prid")] paket paket)
        {

            var paketlers = db.pakets.Where(a => a.padi == paket.padi).FirstOrDefault();

            if (paketlers == null)
            {
                if (paket.pyazi == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Yazı Yazılmadı");
                    return View();
                }
                if (paket.pkampdetay == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Kısa Yazı Yazılmadı");
                    return View();
                }
                if (paket.padi == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Paket Adı Yazılmadı");
                    return View();
                }
                if (paket.paysayi == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Ay Sayısı Yazılmadı");
                    return View();
                }
                if (paket.pkampdetay == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Kapamyan Detay Yazılmadı");
                    return View();
                }
                //eğer dosya gelmişse işlemleri yap

                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                paket.kid = WebSecurity.GetUserId(User.Identity.Name);
                paket.purl = paket.padi.Seo();
                paket.ptarih = DateTime.Now;
                paket.pipadres = "1";
                paket.paktif = true;
                db.pakets.Add(paket);
                db.SaveChanges();
                ModelState.AddModelError("", "Kayıt Başarılı");
                return View();
            }
            else
            {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Aynı ad bulunakta.");
                return View();
            }
        }

        // GET: admin/pakets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.pakets.Find(id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi");
            ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi");
            ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi");
            return View(paket);
        }

        // POST: admin/pakets/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "pid,kid,kateid,padi,psenecekay1,psenecekay2,psenecekay3,psenecekay4,purl,pipadres,psenecekaciklama1,psenecekaciklama2,psenecekaciklama3,psenecekaciklama4," +
            "psenecekfiyat1,psenecekfiyat2,psenecekfiyat3,psenecekfiyat4" +
            "paciklama,pfiyat,ptaraftar,ptarih,pdizi,pfilm,pspor,pmenuekle,pinadi,pinadi2,pinadi3,pinadi4,pinhiz,pinhiz2,pinhiz3,pinhiz4," +
            "pinfiyat,pinfiyat2,pinfiyat3,pinfiyat4,pkampdetay,pinternet,paktif,pyazi,paysayi,panasayfaekle,prid")] paket paket)
        {

                if (paket.pyazi == null)
                {
                    ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                    ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                    ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                    ModelState.AddModelError("", "Yazı Yazılmadı");
                    return View();
                }
                if (paket.pkampdetay == null)
                {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Kısa Yazı Yazılmadı");
                    return View();
                }
                if (paket.padi == null)
                {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Paket Adı Yazılmadı");
                    return View();
                }
                if (paket.paysayi == null)
                {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Ay Sayısı Yazılmadı");
                    return View();
                }
                if (paket.pkampdetay == null)
                {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Kapamyan Detay Yazılmadı");
                    return View();
                }
            //eğer dosya gelmişse işlemleri yap

            if (ModelState.IsValid)
            {

                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                paket.kid = WebSecurity.GetUserId(User.Identity.Name);
                paket.purl = paket.padi.Seo();
                paket.ptarih = paket.ptarih;
                paket.pipadres = "1";
                paket.paktif = paket.paktif; ;
                db.Entry(paket).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.AddModelError("", "Düzenleme Başarılı");
                return View();
            }
            else
            {
                ViewBag.kateid = new SelectList(db.kategoris, "kateid", "kateadi", paket.kateid);
                ViewBag.kid = new SelectList(db.kullanicis, "kid", "kadi", paket.kid);
                ViewBag.prid = new SelectList(db.paketResims, "prid", "presimadi", paket.prid);
                ModelState.AddModelError("", "Eklerken Hata Oluştu.");
                return View();
            }
        }

        // GET: admin/pakets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.pakets.Find(id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
        }

        // POST: admin/pakets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paket paket = db.pakets.Find(id);
            db.pakets.Remove(paket);
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
