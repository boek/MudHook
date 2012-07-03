using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MudHook.UI.Areas.Admin.Models;
using MudHook.Core;

namespace MudHook.UI.Areas.Admin.Controllers
{
    public class MetadataController : Controller
    {
        MudHookRepository repo = new MudHookRepository();

        public ActionResult Index()
        {            
            MetadataModel md = new MetadataModel()
            {
                SiteName = MetaData.SiteName,
                SiteDescription = MetaData.SiteDescription,
                HomePage = MetaData.HomePage,
                PostsPage = MetaData.PostsPage,
                PostsPerPage = MetaData.PostsPerPage,
                Theme = MetaData.Theme,
                AutoPublishComments = Convert.ToBoolean(MetaData.AutoPublishComments),
                Twitter = MetaData.TwitterAccount

            };
            return View(md);
        }

        [HttpPost]
        public ActionResult Index(MetadataModel metadata)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MetaData.Update(metadata);

                    MudHookNotifications.Set(new Notification("success", "Your metadata has been updated"));

                    return RedirectToAction("Index", "Metadata");
                }
                catch (ArgumentException ae)
                {
                    MudHookNotifications.Set(new Notification("error", ae.Message));
                }
            }

            return View();
        }

    }
}
