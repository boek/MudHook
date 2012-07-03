using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MudHook.Core;
using System.Data;

namespace MudHook.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private MudHookRepository repo = new MudHookRepository();        

        public ActionResult Index()
        {
            return View(repo.GetAllPages());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Page page)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(page.Slug))
                    page.Slug = page.Title;

                try
                {
                    repo.AddPage(page);
                    MudHookNotifications.Set(new Notification("success", "Your new page has been added"));
                    return RedirectToAction("Index");
                }
                catch (ArgumentException ae)
                {
                    MudHookNotifications.Set(new Notification("error", ae.Message));
                }
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                string message = "";
                foreach (var e in allErrors)
                {
                    message += e.ErrorMessage + ",";
                }
                MudHookNotifications.Set(new Notification("error", message.TrimEnd()));
            }

            return View(page);
        }

        public ActionResult Edit(int id)
        {
            Page page = repo.GetPage(id);
            return View(page);
        }

        [HttpPost]
        public ActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(page.Slug))
                    page.Slug = page.Title;

                try
                {
                    repo.EditPage(page);
                    MudHookNotifications.Set(new Notification("success", "Your page has been updated."));
                    return RedirectToAction("Index");
                }
                catch (ArgumentException ae)
                {
                    MudHookNotifications.Set(new Notification("error", ae.Message));
                }
            }
            return View(page);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Page page = repo.GetPage(id);
            if (page.Slug == MetaData.HomePage || page.Slug == MetaData.PostsPage)
            {
                MudHookNotifications.Set(new Notification("error", "Sorry, your can not delete you home page or posts page."));
                return Edit(page.Id);
            }
            repo.DeletePage(id);            
            MudHookNotifications.Set(new Notification("success", "Your page has been deleted"));
            return RedirectToAction("Index");
        }        
    }
}
