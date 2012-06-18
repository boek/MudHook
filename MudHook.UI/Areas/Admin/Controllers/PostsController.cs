using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MudHook.Core;

namespace MudHook.UI.Areas.Admin.Controllers
{ 
    [Authorize]
    public class PostsController : Controller
    {
        private MudHookRepository repo = new MudHookRepository();        

        public ViewResult Index()
        {
            return View(repo.GetAllPosts());
        }       

        public ActionResult Add()
        {
            return View();
        }         

        [HttpPost]        
        public ActionResult Add(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;                
                post.LastModified = DateTime.Now;
                //post.Status = 1;
                post.Author = 1;  

                MudHookNotifications.Set(new Notification("success", "Your new post has been added"));

                repo.AddPost(post);                
                return RedirectToAction("Index");
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

            return View(post);
        }
                
        public ActionResult Edit(int id)
        {
            Post post = repo.GetPost(id);            
            return View(post);
        }
       
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                repo.EditPost(post);
                MudHookNotifications.Set(new Notification("success", "Your post has been updated."));
                return RedirectToAction("Index");
            }
            return View(post);
        }
       
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {                        
            repo.DeletePost(id);                   
            MudHookNotifications.Set(new Notification("success", "Your post has been deleted"));
            return RedirectToAction("Index");
        }
       
    }
}