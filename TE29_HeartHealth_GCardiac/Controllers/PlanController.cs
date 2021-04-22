using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            return View();
        }

        // GET: Plan/MakePlan
        public ActionResult MakePlan()
        {
            List<string> list = (List<string>)TempData["exeList"];
            if (list == null)
            {
                return RedirectToAction("Create", "Preference");
            }
            ViewBag.dropDownList = list;
            return View();
        }
    }
}