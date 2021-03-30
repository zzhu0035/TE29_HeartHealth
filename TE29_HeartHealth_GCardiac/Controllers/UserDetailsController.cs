using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;
using Microsoft.AspNet.Identity;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class UserDetailsController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();

        // GET: UserDetails
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user_detail = db.user_details.Where(s => s.UserId ==
            userId).ToList();
            return View(user_detail);
        }

        // GET: UserDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_details user_details = db.user_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // GET: UserDetails/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "age,height,weight,heart_rate")] user_details user_details)
        {
            user_details.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(user_details);

            if (ModelState.IsValid)
            {
                db.user_details.Add(user_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_details);
        }

        // GET: UserDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_details user_details = db.user_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "age,height,weight,heart_rate,UserId")] user_details user_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_details);
        }

        // GET: UserDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_details user_details = db.user_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // POST: UserDetails/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_details user_details = db.user_details.Find(id);
            db.user_details.Remove(user_details);
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
