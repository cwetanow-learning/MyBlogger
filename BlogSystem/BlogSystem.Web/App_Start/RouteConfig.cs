using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "Blog/{page}",
                defaults: new { controller = "Blog", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "Profile/{username}",
                defaults: new { controller = "Profile", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "Post/List/{byDate}-{byRating}",
                defaults: new { controller = "Post", action = "List", page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "Posts/{postId}",
                defaults: new { controller = "Post", action = "PostView" }

            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
