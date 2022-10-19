using digiturkveri;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace digiturkpartnerweb.Models
{
    public static class Data
    {

        public static digiturkveri.paket[] Paketkategori
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pmenuekle == true && p.ptaraftar == true).OrderByDescending(p=>p.ptarih).Take(1).ToArray();
                }
            }
        }
        public static digiturkveri.paket[] Paketkategori1
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pmenuekle == true && p.pspor == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }
        public static digiturkveri.paket[] atlar
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pmenuekle == true && p.pinternet == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] menu
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pmenuekle == true).OrderByDescending(p => p.ptarih).Take(3).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] footer1
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pmenuekle == true).OrderByDescending(p => p.ptarih).Take(5).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] footer2
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.paktif == true).OrderByDescending(p => p.ptarih).Take(5).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] spor
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pspor == true && p.panasayfaekle == true && p.paktif == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] taraftar
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.ptaraftar == true && p.panasayfaekle == true && p.paktif == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] anasayfa
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.paktif == true).OrderByDescending(p => p.ptarih).Take(10).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] dizi
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pdizi == true && p.panasayfaekle == true && p.paktif == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }


        public static digiturkveri.Site_Ayar[] siteayar
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.Site_Ayars.OrderByDescending(p=>p.ayarid).ToArray();
                }
            }
        }

        public static digiturkveri.paket[] film
        {
            get
            {
                using (digiturkEntities db = new digiturkEntities())
                {
                    return db.pakets.Where(p => p.pfilm == true && p.panasayfaekle == true && p.paktif == true).OrderByDescending(p => p.ptarih).Take(1).ToArray();
                }
            }
        }

    }
}