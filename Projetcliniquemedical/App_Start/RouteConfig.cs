using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projetcliniquemedical
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Connecter",
              url: "{controller}/{action}",

              defaults: new { controller = "Home", action = "Connecter", id = UrlParameter.Optional }

          );
            routes.MapRoute(
             name: "Login",
             url: "{controller}/{action}",

             defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }

         );
           








        }
    }
}
