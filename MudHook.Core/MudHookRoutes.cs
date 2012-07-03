using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MudHook.Core
{
    public class MudHookRoutes
    {        
        private static string postPage
        {
            get
            {
                return MetaData.PostsPage;
            }
        }
        private static string homePage
        {
            get
            {
                return MetaData.HomePage;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            
            routes.MapRoute(
                "post", // Route name
                postPage + "/{slug}", // URL with parameters
                new { controller = "Home", action = "Article" } // Parameter defaults
            );

            routes.MapRoute(
                "page", // Route name
                "{slug}", // URL with parameters
                new { controller = "Home", action = "Page", slug = homePage } // Parameter defaults
            );

        }
        public static void UpdateRouteRegistration()
        {
            RouteCollection routes = RouteTable.Routes;
            using (routes.GetWriteLock())
            {
                routes.Clear();
                AreaRegistration.RegisterAllAreas();
                MudHookRoutes.RegisterRoutes(routes);
            }
        }
        
    }
}
