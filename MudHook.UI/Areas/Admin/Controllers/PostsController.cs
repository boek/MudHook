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
        private MudHookContext db = new MudHookContext();

        //
        // GET: /Admin/Post/

        public ViewResult Index()
        {
            return View(db.Posts.ToList());
        }

        //
        // GET: /Admin/Post/Details/5

        public ViewResult Details(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        //
        // GET: /Admin/Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Post/Create

        [HttpPost]        
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;
                post.IsModified = false;
                post.LastModified = DateTime.Now;
                //post.Status = 1;
                post.Author = 1;
                post.CommentsEnabled = true;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(post);
        }
        
        //
        // GET: /Admin/Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /Admin/Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Admin/Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /Admin/Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}