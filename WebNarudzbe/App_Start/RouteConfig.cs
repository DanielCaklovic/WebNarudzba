using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebNarudzbe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Narudzbe",
                url: "{controller}/{action}/{narudzbeID}/{proizvodID}/{kupacID}",
                defaults: new { controller = "Narudzbe", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Narudzbe", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
