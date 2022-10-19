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
    public class kullanicisController : Controller
    {
        private digiturkEntities db = new digiturkEntities();

        // GET: admin/kullanicis
        public ActionResult Index()
        {
            return View(db.kullanicis.ToList());
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        // GET: admin/kullanicis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanicis.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: admin/kullanicis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/kullanicis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kid,kadi,ksifre,ksifretekrar,kaktifmi,kolusturmatarih,kemail,kurl")] kullanici kullanicis)
        {

            var Kullaniciss = db.kullanicis.Where(a => a.kemail == kullanicis.kemail).FirstOrDefault();

            if (Kullaniciss == null)
            {
                if (kullanicis.ksifre == null)
                {
                    ModelState.AddModelError("", "Şifre Girilmedi");
                    return View();
                }

                if (kullanicis.ksifretekrar == null)
                {
                    ModelState.AddModelError("", "Şifre Tekrar Girilmedi");
                    return View();
                }

                if (kullanicis.kadi == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Girilmedi");
                    return View();
                }

                if (kullanicis.kemail == null)
                {
                    ModelState.AddModelError("", "Telefon Numarası Girilmedi");
                    return View();
                }

                kullanicis.kaktifmi = true;
                kullanicis.kolusturmatarih = DateTime.Now;
                kullanicis.kurl = kullanicis.kadi.Seo();
                kullanicis.ksifre = kullanicis.ksifre.Md5();
                db.kullanicis.Add(kullanicis);
                db.SaveChanges();
                System.Web.Security.Roles.AddUserToRole(kullanicis.kadi, "Admin");
                ModelState.AddModelError("", "Kayıt Başarılı");
                return View(kullanicis);
            }
            else
            {
                ModelState.AddModelError("", "E-posta adresi bulunmakta.");
                return View();
            }         
        }

        public ActionResult kullaniciolustur()
        {
            return View();
        }

        // POST: admin/kullanicis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult kullaniciolustur([Bind(Include = "kid,kadi,ksifre,ksifretekrar,kaktifmi,kolusturmatarih,kemail,kurl")] kullanici kullanicis)
        {

            var Kullaniciss = db.kullanicis.Where(a => a.kemail == kullanicis.kemail).FirstOrDefault();

            if (Kullaniciss == null)
            {
                if (kullanicis.ksifre == null)
                {
                    ModelState.AddModelError("", "Şifre Girilmedi");
                    return View();
                }

                if (kullanicis.ksifretekrar == null)
                {
                    ModelState.AddModelError("", "Şifre Tekrar Girilmedi");
                    return View();
                }

                if (kullanicis.kadi == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Girilmedi");
                    return View();
                }

                if (kullanicis.kemail == null)
                {
                    ModelState.AddModelError("", "Telefon Numarası Girilmedi");
                    return View();
                }

                kullanicis.kaktifmi = true;
                kullanicis.kolusturmatarih = DateTime.Now;
                kullanicis.kurl = kullanicis.kadi.Seo();
                kullanicis.ksifre = kullanicis.ksifre.Md5();
                db.kullanicis.Add(kullanicis);
                db.SaveChanges();
                System.Web.Security.Roles.AddUserToRole(kullanicis.kadi, "Kullanici");
                ModelState.AddModelError("", "Kayıt Başarılı");
                return View(kullanicis);
            }
            else
            {
                ModelState.AddModelError("", "E-posta adresi bulunmakta.");
                return View();
            }
        }

        // GET: admin/kullanicis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanicis.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: admin/kullanicis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kid,kadi,ksifre,ksifretekrar,kaktifmi,kolusturmatarih,kemail,kurl")] kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.kaktifmi = kullanici.kaktifmi;
                kullanici.kurl = kullanici.kadi.Seo();
                kullanici.ksifre = kullanici.ksifre.Md5();
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: admin/kullanicis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanicis.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: admin/kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kullanici kullanici = db.kullanicis.Find(id);
            db.kullanicis.Remove(kullanici);
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
