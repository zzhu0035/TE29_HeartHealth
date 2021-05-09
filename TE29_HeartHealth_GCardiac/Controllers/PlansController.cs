using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PlansController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();

        // GET: Plans
        [Authorize]
        public ActionResult Index()
        {
            List<object> list = (List<object>)TempData["exeList"];
            ViewBag.exeList = list;
            TempData["exeList"] = list;
            return View(db.Plans.ToList());
        }

        // GET: Plans/Create
        [Authorize]
        public ActionResult Create()
        {
            List<object> list = (List<object>)TempData["exeList"];
            if (list == null)
            {
                return RedirectToAction("Create", "Preference");
            }
            ViewBag.Exercise = new SelectList(list, "Value", "Text");
            TempData["exeList"] = list;
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Exercise,StartTime,EndTime")] Plans plans)
        {
            List<object> list = (List<object>)TempData["exeList"];
            TempData["exeList"] = list;
            var userId = User.Identity.GetUserId();
            plans.Calorie = "0";
            plans.UserId = userId;
            ModelState.Clear();
            TryValidateModel(plans);
            if (ModelState.IsValid)
            {
                db.Plans.Add(plans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Exercise = new SelectList(list, "Value", "Text", plans.Exercise);
            return View(plans);
        }

        // GET: Plans/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Exercise,Calorie,StartTime,EndTime,UserId")] Plans plans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plans);
        }

        // GET: Plans/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Plans plans = db.Plans.Find(id);
            db.Plans.Remove(plans);
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
