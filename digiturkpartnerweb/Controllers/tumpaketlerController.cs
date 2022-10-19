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
    public class tumpaketlerController : Controller
    {
        // GET: tumpaketler

        private digiturkEntities db = new digiturkEntities();

        public ActionResult Index()
        {
            var paket = db.pakets.Include(b => b.kategori).Where(p => p.paktif == true).OrderByDescending(p => p.ptarih);
            ViewBag.Aktifblog = db.pakets.Include(b => b.kategori).Where(p => p.paktif == false).ToList();
            return View(paket.ToList());
        }

        public ActionResult basarili()
        {
            var paket = db.pakets.Include(b => b.kategori).Where(p => p.paktif == true).OrderByDescending(p => p.ptarih);
            ViewBag.Aktifblog = db.pakets.Include(b => b.kategori).Where(p => p.paktif == false).ToList();
            return View(paket.ToList());
        }

        public ActionResult hata()
        {
            var paket = db.pakets.Include(b => b.kategori).Where(p => p.paktif == true).OrderByDescending(p => p.ptarih);
            ViewBag.Aktifblog = db.pakets.Include(b => b.kategori).Where(p => p.paktif == false).ToList();
            return View(paket.ToList());
        }

        public ActionResult basvuru([Bind(Include = "basvuruadisoyadi,basipadres,basvurutarih,basvurutel,basvurukabul,pid")] basvuru basvuru, string kelime, string basipadress, string tele, int? numara)
        {

            var basvurular = db.basvurus.Where(a => a.basvuruadisoyadi == kelime).FirstOrDefault();

            if (basvurular == null)
            {

                if (kelime == null)
                {
                    return RedirectToAction("hata");
                }

                if (numara == null)
                {
                    return RedirectToAction("hata");
                }

                if (tele == null)
                {
                    return RedirectToAction("hata");
                }

                basvuru.basipadres = basipadress;
                basvuru.basvuruadisoyadi = kelime;
                basvuru.basvurutel = tele;
                basvuru.pid = numara;
                basvuru.basvurutarih = DateTime.Now.ToString("dd-MM-yyyy");
                basvuru.basvurukabul = true;
                db.basvurus.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("basarili");
            }
            else
            {
                return RedirectToAction("hata");
            }
        }

        public ActionResult basvuru2([Bind(Include = "basvuruadisoyadi,basipadres,basvurutarih,basvurutel,basvurukabul,pid")] basvuru basvuru, string kelime1, string tele1, int? numara1, string basipadres1)
        {

            var basvurular = db.basvurus.Where(a => a.basvuruadisoyadi == kelime1).FirstOrDefault();

            if (basvurular == null)
            {

                if (kelime1 == null)
                {
                    return RedirectToAction("hata");
                }

                if (numara1 == null)
                {
                    return RedirectToAction("hata");
                }

                if (tele1 == null)
                {
                    return RedirectToAction("hata");
                }


                basvuru.basvuruadisoyadi = kelime1;
                basvuru.basipadres = basipadres1;
                basvuru.basvurutel = tele1;
                basvuru.basvurutarih = DateTime.Now.ToString("dd-MM-yyyy");
                basvuru.pid = numara1;
                basvuru.basvurukabul = true;
                db.basvurus.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("basarili");
            }
            else
            {
                return RedirectToAction("hata");
            }

        }

        public ActionResult anasayfadan([Bind(Include = "basvuruadisoyadi,basipadres,basvurutarih,basvurutel,basvurukabul,pid")] basvuru basvuru, string kelime, string tele, string ipadresim)
        {

            //
            //try
            //{


            var basvurular = db.basvurus.Where(a => a.basvuruadisoyadi == kelime).FirstOrDefault();

            if (basvurular == null)
            {

                if (kelime == null)
                {
                    return RedirectToAction("hata");
                }


                if (tele == null)
                {
                    return RedirectToAction("hata");
                }

                basvuru.basipadres = ipadresim;
                basvuru.basvuruadisoyadi = kelime;
                basvuru.basvurutel = tele;
                basvuru.pid = 1;
                basvuru.basvurutarih = DateTime.Now.ToString("dd-MM-yyyy");
                basvuru.basvurukabul = true;
                db.basvurus.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("basarili");
            }
            else
            {
                return RedirectToAction("hata");
            }

        }
        //catch (Exception ex)
        //{
        //    string aaa = ex.Message;
        //    int a = 11;
        //    return RedirectToAction("hata");

        //}
    }
}
