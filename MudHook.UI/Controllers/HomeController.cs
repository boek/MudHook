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
        private readonly MudHookContext _db = new MudHookContext();

        public ActionResult Index()
        {
            return View(_db.Posts.ToList());
        }

    }
}
