using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRate.Models;

namespace WebRate.Controllers
{
    public class TopicCommentsController : Controller
    {
        private string UserID;
        private ApplicationDbContext db = new ApplicationDbContext();

        public TopicCommentsController()
        {
            UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }


       

        // GET: TopicComments
        public ActionResult Index()
        {
            var topicComments = db.TopicComments.Include(t => t.Topic);
            return View(topicComments.ToList());
        }

        // GET: TopicComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicComment topicComment = db.TopicComments.Find(id);
            if (topicComment == null)
            {
                return HttpNotFound();
            }
            return View(topicComment);
        }

        // GET: TopicComments/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Tittle");
            return View();
        }

        // POST: TopicComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TopicComment topicComment)
        {
            if (ModelState.IsValid)
            {
                topicComment.UserID = UserID;

                db.TopicComments.Add(topicComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Tittle", topicComment.TopicID);
            return View(topicComment);
        }

        // GET: TopicComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicComment topicComment = db.TopicComments.Find(id);
            if (topicComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Tittle", topicComment.TopicID);
            return View(topicComment);
        }

        // POST: TopicComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TopicComment topicComment)
        {
            if (ModelState.IsValid)
            {
                topicComment.UserID = UserID;

                db.Entry(topicComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Tittle", topicComment.TopicID);
            return View(topicComment);
        }

        // GET: TopicComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicComment topicComment = db.TopicComments.Find(id);
            if (topicComment == null)
            {
                return HttpNotFound();
            }
            return View(topicComment);
        }

        // POST: TopicComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopicComment topicComment = db.TopicComments.Find(id);
            db.TopicComments.Remove(topicComment);
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
