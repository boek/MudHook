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
        public static string postPage
        {
            get{
                MudHookRepository repo = new MudHookRepository();
                return repo.GetMeta("PostsPage").Value;
            }
        }
        public static string homePage
        {
            get
            {
                MudHookRepository repo = new MudHookRepository();
                return repo.GetMeta("HomePage").Value;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "post", // Route name
                postPage + "/{slug}", // URL with parameters
                new { controller = "Home", action = "Article", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "page", // Route name
                "{slug}", // URL with parameters
                new { controller = "Home", action = "Page", slug = homePage } // Parameter defaults
            );

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);

        }
        
    }
}
