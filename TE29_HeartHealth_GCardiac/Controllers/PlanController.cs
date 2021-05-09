﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PlanController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();

        // GET: Plan
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var id = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Id).First();
            if (db.FamilyMember.Where(s => s.UserId == id).Count() > 0)
            {
                return View();
            } else
            {
                return RedirectToAction("Create", "Preference", new { type = "person" });
            }
        }
    }
}