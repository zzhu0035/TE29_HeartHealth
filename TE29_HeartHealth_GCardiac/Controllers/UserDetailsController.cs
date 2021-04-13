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
            var userDetails = db.UserDetails.Where(s => s.UserId == userId).ToList();
            if(userDetails.Count == 0)
            {
                return View();
            } else
            {
                var maxId = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Id).Max();
                var userDetailsList = db.UserDetails.Where(s => s.Id == maxId).ToList();
                return View(userDetailsList[0]);

            }
            
        }

        // GET: UserDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
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
        public ActionResult Create([Bind(Include = "Id,Age,Height,Weight,HeartRate")] UserDetails userDetails)
        {
            userDetails.UserId = User.Identity.GetUserId();
            userDetails.Date = DateTime.Now;
            ModelState.Clear();
            TryValidateModel(userDetails);

            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Age,Height,Weight,HeartRate")] UserDetails userDetails)
        {
            userDetails.UserId = User.Identity.GetUserId();
            userDetails.Date = DateTime.Now;
            ModelState.Clear();
            TryValidateModel(userDetails);

            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetails userDetails = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetails);
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
