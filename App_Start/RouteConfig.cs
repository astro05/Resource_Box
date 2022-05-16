using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ResourceBox
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
          "Authentication",
         "{controller}/{action}/{id}",
          new { controller = "Authentication", action = "Login", id = UrlParameter.Optional });
          
            routes.MapRoute(
         "User",
        "{controller}/{action}/{id}",
         new { controller = "User", action = "UserProfile", id = UrlParameter.Optional });

            routes.MapRoute(
        "Resource",
       "{controller}/{action}/{id}",
        new { controller = "Resources", action = "ViewBook", id = UrlParameter.Optional });

        }
    }
}
