using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicacaoComCodeFirst.Models;

namespace ApplicacaoComCodeFirst.Controllers
{
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /Posts/

        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Categorias);
            return View(posts.ToList());
        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(int id = 0)
        {
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria");
            return View();
        }

        //
        // POST: /Posts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        //
        // GET: /Posts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        //
        // GET: /Posts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        //
        // POST: /Posts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posts posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
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