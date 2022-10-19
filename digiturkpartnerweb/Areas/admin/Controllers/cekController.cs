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
using digiturkpartnerweb.Areas.admin.Models;
using System.Xml;
using System.Text;
using System.Web.Helpers;

namespace digiturkpartnerweb.Areas.admin.Controllers
{
    public class cekController : Controller
    {
        private digiturkEntities db = new digiturkEntities();
        // GET: admin/cek
        public ActionResult Index([Bind(Include = "basvuruid,basvuruadisoyadi,basvurutarih,basvurutel,basvurukabul,basipadres,pid")] basvuru basvuru, veri versifre, string id)
        {
            var basvurularr = db.basvurus
            .Include(p => p.paket)
            .FirstOrDefault(p => p.basvurukabul && p.basvurutarih == id);

            if (basvurularr == null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("hata");
            }

        }
        public JsonResult BirimGetir([Bind(Include = "basvuruid,basvuruadisoyadi,basvurutarih,basvurutel,basvurukabul,basipadres,pid")] basvuru basvuru2, veri versifre,string id2)
        {
            string enc_sifre = "5305804345huSeyiN";

            var AkademikBirimListe = db.basvurus.Include(b => b.paket);

            return this.Json(AkademikBirimListe.ToList(), JsonRequestBehavior.AllowGet);

           

        }
    }
}
