using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rebbit.Models;

namespace Rebbit.Controllers
{
    public class PostzsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Postzs
        public ActionResult Index()
        {
            return View(db.RebbitPosts.ToList());
        }

        // GET: Postzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postz postz = db.RebbitPosts.Find(id);
            if (postz == null)
            {
                return HttpNotFound();
            }
            return View(postz);
        }

        // GET: Postzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,ImageUrl,Description")] Postz postz)
        {
            if (ModelState.IsValid)
            {
                db.RebbitPosts.Add(postz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postz);
        }

        // GET: Postzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postz postz = db.RebbitPosts.Find(id);
            if (postz == null)
            {
                return HttpNotFound();
            }
            return View(postz);
        }

        // POST: Postzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,TimePosted,Upvote,Downvote,ImageUrl,Description,UserId")] Postz postz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postz);
        }

        // GET: Postzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postz postz = db.RebbitPosts.Find(id);
            if (postz == null)
            {
                return HttpNotFound();
            }
            return View(postz);
        }

        // POST: Postzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postz postz = db.RebbitPosts.Find(id);
            db.RebbitPosts.Remove(postz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
