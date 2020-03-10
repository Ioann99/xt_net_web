using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task_1.PL.WEB_UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "users/",
                defaults: new { controller = "Users", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "users/{query}",
                defaults: new { controller = "Users", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "create-user/",
                defaults: new { controller = "Users", action = "Create" }
                );

            routes.MapRoute(
                name: null,
                url: "user/{id}",
                defaults: new { controller = "Users", action = "Details" }
                );

            routes.MapRoute(
                name: null,
                url: "user/{id}/edit",
                defaults: new { controller = "Users", action = "Edit" }
                );

            routes.MapRoute(
                name: null,
                url: "user/{id}/delete",
                defaults: new { controller = "Users", action = "Delete" }
                );

            routes.MapRoute(
                name: null,
                url: "recipies/",
                defaults: new { controller = "Recipies", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "recipies/{query}",
                defaults: new { controller = "Recipies", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "create-recipie/",
                defaults: new { controller = "Recipies", action = "Create" }
                );

            routes.MapRoute(
                name: null,
                url: "recipie/{id}",
                defaults: new { controller = "Recipies", action = "Details" }
                );

            routes.MapRoute(
                name: null,
                url: "recipie/{id}/edit",
                defaults: new { controller = "Recipies", action = "Edit" }
                );

            routes.MapRoute(
                name: null,
                url: "recipie/{id}/delete",
                defaults: new { controller = "Recipies", action = "Delete" }
                );

            routes.MapRoute(
                name: null,
                url: "recipie-user/{userId_recipieId}",
                defaults: new { controller = "Users", action = "recipieUserByUrl" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{controller}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
