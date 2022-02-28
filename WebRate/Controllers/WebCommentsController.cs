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
    public class WebCommentsController : Controller
    {
        private string UserID;
        private ApplicationDbContext db = new ApplicationDbContext();

        public WebCommentsController()
        {
            UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }

       

        // GET: WebComments
        public ActionResult Index()
        {
            var webComments = db.WebComments.Include(w => w.Website);
            ViewBag.UID = UserID;
            return View(webComments.ToList());
        }

        // GET: WebComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebComment webComment = db.WebComments.Find(id);
            if (webComment == null)
            {
                return HttpNotFound();
            }
            return View(webComment);
        }

        // GET: WebComments/Create
        public ActionResult Create()
        {
            ViewBag.WebID = new SelectList(db.Websites, "WebID", "Tittle");
            return View();
        }

        // POST: WebComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( WebComment webComment)
        {
            if (ModelState.IsValid)
            {
                webComment.UserID = UserID;
                db.WebComments.Add(webComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WebID = new SelectList(db.Websites, "WebID", "Tittle", webComment.WebID);
            return View(webComment);
        }

        // GET: WebComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebComment webComment = db.WebComments.Find(id);
            if (webComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.WebID = new SelectList(db.Websites, "WebID", "Tittle", webComment.WebID);
            return View(webComment);
        }

        // POST: WebComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( WebComment webComment)
        {
            if (ModelState.IsValid)
            {
                webComment.UserID = UserID;

                db.Entry(webComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WebID = new SelectList(db.Websites, "WebID", "Tittle", webComment.WebID);
            return View(webComment);
        }

        // GET: WebComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebComment webComment = db.WebComments.Find(id);
            if (webComment == null)
            {
                return HttpNotFound();
            }
            return View(webComment);
        }

        // POST: WebComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebComment webComment = db.WebComments.Find(id);
            db.WebComments.Remove(webComment);
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
