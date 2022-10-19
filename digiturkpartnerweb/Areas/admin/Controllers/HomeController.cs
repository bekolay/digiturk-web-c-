using digiturkpartnerweb.Controllers;
using digiturkveri;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace digiturkpartnerweb.Areas.admin.Controllers
{

    public class HomeController : Controller
    {
        // GET: admin/Home
        private digiturkEntities db = new digiturkEntities();

        [Authorize(Roles = "Admin,Kullanici")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(LoginModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //string password = Tools.Md5(model.Password);
                string password = model.Sifre.Md5();

                kullanici user = db.kullanicis.FirstOrDefault(p => p.kemail == model.KullaniciAdi && p.ksifre == password);

                if (user == null)
                {
                    ViewBag.Error = "Kullanıcı Adınız veya Şifreniz Hatalı";
                    return View();
                }

                if (user.kaktifmi == false)
                {
                    ViewBag.Error = "Banlandınız acaba kim bilir ne yaptınız :)";
                    return View();
                }


                FormsAuthentication.RedirectFromLoginPage(user.kadi.ToString(), model.BeniHatirla);
            }

            return Redirect(ReturnUrl ?? "/admin");
        }
    }
}