using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace digiturkpartnerweb.Controllers
{
    public class LoginModel
    {
        [Required(ErrorMessage="Kullanıcı Adı Boş Geçilemez")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage="Şifre Boş Geçilemez")]
        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}