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
    public class FamilyMembersController : Controller
    {
        private FamilyModel db = new FamilyModel();
        private UserDetailsModels db1 = new UserDetailsModels();

        // GET: FamilyMembers
        public ActionResult Index()
        {
            return View(db.FamilyMember.ToList());
        }

        // GET: FamilyMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMember.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Age,Height,Weight,HeartRate")] FamilyMember familyMember)
        {
            var userId = User.Identity.GetUserId();
            familyMember.UserId = db1.UserDetails.Where(s => s.UserId == userId).Select(s=>s.Id).First();
            familyMember.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.FamilyMember.Add(familyMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyMember);
        }

        // GET: FamilyMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMember.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Age,Height,Weight,HeartRate")] FamilyMember familyMember)
        {
            familyMember.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(familyMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMember.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyMember familyMember = db.FamilyMember.Find(id);
            db.FamilyMember.Remove(familyMember);
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
