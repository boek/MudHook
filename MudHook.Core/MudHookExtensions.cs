using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace MudHook.Core
{
    public static class MudHookExtensions
    {
        public static string AdminUrl(this HtmlHelper helper)
        {
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            return url.RouteUrl("Admin", new { controller = "Posts", action = "Index" });
        }                

    }
}
