using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MudHook.Core;

namespace MudHook.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MudHookRepository repo = new MudHookRepository();
        
        public ActionResult Index(string slug)
        {
            if (slug.ToLower() == MetaData.PostsPage.ToLower())
                return View("listPosts", repo.GetAllPosts());
            else
                return View("page", repo.GetPage(slug));
        }

        public ActionResult article(string slug)
        {
            return View(repo.GetPost(slug));
        }

        public ActionResult page(string slug)
        {
            return View(repo.GetPage(slug));
        }

        public ActionResult RenderNavigation()
        {
            return PartialView("_RenderNavigation", repo.GetAllPages());
        }
    }
}
