using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcBootcamp.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Panel",
                url: "panel",
                defaults: new { controller = "Panel", action = "Index" }
            );

            routes.MapRoute(
                name: "Giriş",
                url: "giris",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Çıkış",
                url: "cikis",
                defaults: new { controller = "Account", action = "Logout" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
