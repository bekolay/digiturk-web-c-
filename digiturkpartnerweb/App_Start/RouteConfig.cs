using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace digiturkpartnerweb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            /*string[] iller = { "ankara", "istanbul" };*/
            //foreach (Route item in routes)
            //{
            //    ///iller = item[]
            //}



            //"ankara", "istanbul";

            //routes.MapRoute(
            //    name: iller,
            //    url: iller,
            //    defaults: new { controller = "Home", action = "Index" },
            //    namespaces: new string[] { "digiturkpartnerweb.Controllers" }
            //);

            //routes.MapRoute(
            //    name: "il",
            //    url: "il/{id}",
            //    defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional }

            //);

            routes.MapRoute(
                name: "tumpaketler",
                url: "tumpaketler",
                defaults: new { controller = "tumpaketler", action = "index", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "anasayfa",
                url: "{id}",
                defaults: new { controller = "Home", action = "il" },
                namespaces: new string[] { "digiturkpartnerweb.Controllers" }

            );


            routes.MapRoute(
                name: "paket",
                url: "paket/{id}",
                defaults: new { controller = "paket", action = "p", id = UrlParameter.Optional }

            );

                routes.MapRoute(
                name: "paketler",
                url: "paketler/{id}",
                defaults: new { controller = "paket", action = "pp", id = UrlParameter.Optional }

            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "digiturkpartnerweb.Controllers" }
            );
        }
        void RouteAdd(RouteCollection route)
        {
            
        }
    }
}
